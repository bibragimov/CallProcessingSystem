using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class UserRequest : BaseEntity<long>
    {
        public UserRequest()
        {
            Status = RequestStatusType.Registered;
        }

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
        ///     Статус
        /// </summary>
        public RequestStatusType Status { get; set; }

        /// <summary>
        ///     Коментарий
        /// </summary>
        public string Comment { get; set; }


        public long ThemeId { get; set; }

        /// <summary>
        ///     Тема обращения
        /// </summary>
        public RequestTheme Theme { get; set; }

        public long OperatorId { get; set; }

        /// <summary>
        ///     Оператор, принявший обращение
        /// </summary>
        public Operator Operator { get; set; }

        /// <summary>
        ///     Ответственный исполнитель
        /// </summary>
        public long ExecutorId { get; set; }

        public Executor Executor { get; set; }
    }
}