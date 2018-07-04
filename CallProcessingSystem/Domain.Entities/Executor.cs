using System.Collections.Generic;

namespace Domain.Entities
{
    public class Executor : Identity
    {
        /// <summary>
        ///     Зарегистрированные заявки
        /// </summary>
        public ICollection<UserRequest> UserRequests { get; set; }
    }
}