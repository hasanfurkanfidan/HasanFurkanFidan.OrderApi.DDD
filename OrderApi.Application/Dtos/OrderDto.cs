using OrderApi.Domain.OrderAggreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public AdressDto Adress { get; private set; }
        public string BuyerId { get; private set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
