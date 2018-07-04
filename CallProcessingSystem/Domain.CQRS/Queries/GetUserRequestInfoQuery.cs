using System.Data.Entity;
using System.Linq;
using CQRS;
using Domain.CQRS.Map;
using Domain.Entities;
using Domain.Entities.Repositories;
using ExpressMapper;

namespace Domain.CQRS.Queries
{
    public class GetUserRequestInfoQuery : IQuery
    {
        public GetUserRequestInfoQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class GetUserRequestInfoQueryHandler : IQueryHandler<GetUserRequestInfoQuery, UserRequestInfoDto>
    {
        private readonly IRepository<UserRequest> _requestRepository;

        public GetUserRequestInfoQueryHandler(IRepository<UserRequest> requestRepository)
        {
            _requestRepository = requestRepository;
        }


        public UserRequestInfoDto Handle(GetUserRequestInfoQuery query)
        {
            var request = _requestRepository.Get().Include(x => x.Theme)
                .Include(x => x.Executor).Include(x => x.Operator)
                .FirstOrDefault(x => x.Id == query.Id);

            if (request == null) return null;

            return Mapper.Map<UserRequest, UserRequestInfoDto>(request);
        }
    }
}