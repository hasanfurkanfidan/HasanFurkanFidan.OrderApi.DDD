using AutoMapper;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderApi.Application.Dtos;
using OrderApi.Application.Mapping;
using OrderApi.Application.Queries;
using OrderApi.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;
        public GetOrdersByUserIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(p => p.OrderItems).Where(p => p.BuyerId == request.UserId).ToListAsync();

            if (orders.Count==0)
            {
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200);
            }
            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return Response<List<OrderDto>>.Success(ordersDto, 200);
        }
    }
}
