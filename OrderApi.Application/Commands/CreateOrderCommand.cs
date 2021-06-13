using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using MediatR;
using OrderApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItemDtos { get; set; }
        public AdressDto AdressDto { get; set; }
    }
}
