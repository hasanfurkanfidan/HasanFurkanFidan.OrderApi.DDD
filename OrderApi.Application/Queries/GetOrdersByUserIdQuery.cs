using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using MediatR;
using OrderApi.Application.Dtos;
using OrderApi.Domain.OrderAggreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
