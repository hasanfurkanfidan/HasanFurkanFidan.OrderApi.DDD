using OrderApi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.OrderAggreggate
{
    public class Order :Entity , IAggreggateRoute
    {
        public DateTime CreatedDate { get;private set; }
        public Adress Adress { get;private set; }
        public string BuyerId { get;private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order(string buyerId,Adress adress)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Adress = adress;
        }
        public Order()
        {

        }
        public void AddOrderItem(string productId,string productName,decimal price,string pictureUrl)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var orderItem = new OrderItem(productId, productName, pictureUrl, price);
            }
        }
        public decimal GetTotalPrice()
        {
            decimal price = 0;
            foreach (var item in _orderItems)
            {
                price = price + item.Price;
            }
            return price;
        }
    }
}
