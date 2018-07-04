using CQRS;
using Domain.Entities;
using Domain.Entities.Repositories;

namespace Domain.CQRS.Commands
{
    public class OperatorCreateUserRequestCommand : ICommand
    {
        /// <summary>
        ///     ФИО обратившегося клиента
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     Текст обращения
        /// </summary>
        public string ComplaintMessage { get; set; }

        /// <summary>
        ///     Тема обращения
        /// </summary>
        public long ThemeId { get; set; }

        /// <summary>
        ///     Оператор
        /// </summary>
        public long OperatorId { get; set; }

        /// <summary>
        ///     Исполнитель
        /// </summary>
        public long ExcecutorId { get; set; }
    }

    public class OperatorCreateUserRequestCommandHandler : ICommandHandler<OperatorCreateUserRequestCommand>
    {
        private readonly IRepository<UserRequest> _requestRepository;

        public OperatorCreateUserRequestCommandHandler(IRepository<UserRequest> requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public void Handle(OperatorCreateUserRequestCommand command)
        {
            _requestRepository.Add(new UserRequest
            {
                ComplaintMessage = command.ComplaintMessage,
                Phone = command.Phone,
                OperatorId = command.OperatorId,
                ThemeId = command.ThemeId,
                UserName = command.UserName,
                ExecutorId = command.ExcecutorId
            });
        }
    }
}