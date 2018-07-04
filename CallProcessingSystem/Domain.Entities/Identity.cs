using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Identity : BaseEntity<long>
    {
        /// <summary>
        ///     Логин пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Автар
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        ///     Роль пол-ля
        /// </summary>
        public RoleType Role { get; set; }

        /// <summary>
        ///     Код восстановления пароля
        /// </summary>
        public int RecoveryPasswordCode { get; set; }

        /// <summary>
        ///     Локаль пол-ля
        /// </summary>
        public string Locale { get; set; }
    }
}