using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CQRS;
using Domain.CQRS.Map;
using Domain.Entities;
using Domain.Entities.Repositories;
using ExpressMapper;

namespace Domain.CQRS.Queries
{
    public class GetUserRequestsQuery : IQuery
    {
        public GetUserRequestsQuery(int page, int take, int status, long? operatorId = null, long? executorId = null)
        {
            Page = page;
            Take = take;
            Status = status;
            OperatorId = operatorId;
            ExecutorId = executorId;
        }

        public int Status { get; set; }

        public int Page { get; set; }

        public int Take { get; set; }

        public long? OperatorId { get; set; }

        public long? ExecutorId { get; set; }

        public int AllCount { get; set; }
    }

    public class GetUserRequestsQueryHandler : IQueryHandler<GetUserRequestsQuery, List<UserRequestDto>>
    {
        private readonly IRepository<UserRequest> _requestRepository;

        public GetUserRequestsQueryHandler(IRepository<UserRequest> requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public List<UserRequestDto> Handle(GetUserRequestsQuery query)
        {
            int count;
            var queryItems = _requestRepository.Get().Include(x => x.Theme);

            queryItems = query.OperatorId.HasValue
                ? queryItems.Where(x => x.OperatorId == query.OperatorId)
                : queryItems;

            queryItems = query.ExecutorId.HasValue
                ? queryItems.Where(x => x.ExecutorId == query.ExecutorId.Value)
                : queryItems;

            var items = queryItems.OrderBy(x => x.CreateDate)
                .Page(query.Page, query.Take, out count).ToList();

            query.AllCount = count;

            return items.Select(Mapper.Map<UserRequest, UserRequestDto>).ToList();
        }
    }
}