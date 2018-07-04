using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class CreateUserRequestViewModel
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
        ///     Исполнитель
        /// </summary>
        public long ExcecutorId { get; set; }


        public IEnumerable<SelectListItem> Themes { get; set; }

        public IEnumerable<SelectListItem> Excecutors { get; set; }
    }
}