using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.EF.Conventions
{
    /// <summary>
    ///     Устанавливает для всех свойств типа DateTime (.net) тип данных datetime2 (Microsoft SQL Server)
    /// </summary>
    internal class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}