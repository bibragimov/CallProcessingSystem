using System.Collections.Generic;
using Domain.CQRS;
using Domain.CQRS.Map;

namespace WebApp.Models
{
    public class IndexViewModel
    {
        public List<UserRequestDto> Items { get; set; }

        public PageInfo PageInfo { get; set; }
    }

}