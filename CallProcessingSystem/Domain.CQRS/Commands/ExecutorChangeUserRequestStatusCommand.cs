using CQRS;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Entities.Repositories;

namespace Domain.CQRS.Commands
{
    public class ExecutorChangeUserRequestStatusCommand : ICommand
    {
        /// <summary>
        ///     Id исполнителя
        /// </summary>
        public long ExecutorId { get; set; }

        /// <summary>
        ///     Id обращения
        /// </summary>
        public long RequestId { get; set; }

        /// <summary>
        ///     Статус
        /// </summary>
        public RequestStatusType Status { get; set; }

        /// <summary>
        ///     Коментарий
        /// </summary>
        public string Comment { get; set; }
    }

    public class ExecutorChangeUserRequestStatusCommandHandler : ICommandHandler<ExecutorChangeUserRequestStatusCommand>
    {
        private readonly IRepository<UserRequest> _userRequestRepository;

        public ExecutorChangeUserRequestStatusCommandHandler(IRepository<UserRequest> userRequestRepository)
        {
            _userRequestRepository = userRequestRepository;
        }

        public void Handle(ExecutorChangeUserRequestStatusCommand command)
        {
            var request = _userRequestRepository.Find(x => x.Id == command.RequestId);
            if (request == null || request.Status == RequestStatusType.Performed)
                return;

            request.Status = command.Status;
            request.Comment = command.Comment;
            _userRequestRepository.AddOrUpdate(request, x => x.Id);
        }
    }
}