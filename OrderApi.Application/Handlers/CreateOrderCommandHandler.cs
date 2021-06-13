using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using MediatR;
using OrderApi.Application.Commands;
using OrderApi.Application.Dtos;
using OrderApi.Domain.OrderAggreggate;
using OrderApi.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;
        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }
        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Adress(city: request.AdressDto.City, district: request.AdressDto.District, street: request.AdressDto.Street, request.AdressDto.ZipCode, line: request.AdressDto.Line);
            var newOrder = new Order(request.BuyerId, newAddress);

            foreach (var item in request.OrderItemDtos)
            {
                newOrder.AddOrderItem(item.ProductId, item.ProductName, item.Price, item.PictureUrl);

            }
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { Id = newOrder.Id }, 200);
        }
    }
}
