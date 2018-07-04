using Domain.Entities.Enums;

namespace WebApp.Models
{
    public class ChangeRequestStatusViewModel
    {
        public long Id { get; set; }

        public RequestStatusType Status { get; set; }

        public string Comment { get; set; }
    }
}