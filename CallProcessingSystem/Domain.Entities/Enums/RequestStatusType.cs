using System.ComponentModel;

namespace Domain.Entities.Enums
{
    public enum RequestStatusType
    {
        /// <summary>
        ///     Зарегистрировано
        /// </summary>
        [Description("Зарегистрировано")] Registered = 0,

        /// <summary>
        ///     Исполнено
        /// </summary>
        [Description("Исполнено")] Performed = 1,

        /// <summary>
        ///     Не исполнено
        /// </summary>
        [Description("Не исполнено")] NotPerformed = 2
    }
}