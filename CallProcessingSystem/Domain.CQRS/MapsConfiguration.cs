using Domain.CQRS.Map;
using Domain.Entities;
using ExpressMapper;

namespace Domain.CQRS
{
    /// <summary>
    ///     Конфигурация маппинга
    /// </summary>
    public class MapsConfiguration
    {
        /// <summary>
        ///     Метод конфигурации с правилами
        /// </summary>
        public static void Configure()
        {
            Mapper.Register<UserRequest, UserRequestDto>()
                .Member(x => x.Theme, y => y.Theme.Title)
                .Member(x => x.CreateDate, y => y.CreateDate.ToString("dd MMMM yyyy"))
                .Member(x => x.ExecutorName, y => y.Executor.Name)
                .Member(x => x.OperatorName, y => y.Operator.Name);

            Mapper.Register<UserRequest, UserRequestInfoDto>()
                .Member(x => x.Theme, y => y.Theme.Title)
                .Member(x => x.CreateDate, y => y.CreateDate.ToString("dd MMMM yyyy"))
                .Member(x => x.ExecutorName, y => y.Executor.Name)
                .Member(x => x.OperatorName, y => y.Operator.Name);
        }
    }
}