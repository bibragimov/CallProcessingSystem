using System.Collections.Generic;

namespace Domain.Entities
{
    public class RequestTheme : BaseEntity<long>
    {
        /// <summary>
        ///     Заголовок обращения
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Заявки пол-лей
        /// </summary>
        public ICollection<UserRequest> UserRequests { get; set; }
    }
}