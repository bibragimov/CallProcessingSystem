using Domain.Entities.Enums;

namespace Domain.CQRS.Map
{
    public class UserRequestDto
    {
        /// <summary>
        ///     Id обращения
        /// </summary>
        public long Id { get; set; }

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
        ///     Тема обращения
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        ///     Имя исполнителя
        /// </summary>
        public string ExecutorName { get; set; }

        /// <summary>
        ///     Имя оператора
        /// </summary>
        public string OperatorName { get; set; }
    }
}