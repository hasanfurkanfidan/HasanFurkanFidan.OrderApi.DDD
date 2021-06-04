﻿using OrderApi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.OrderAggreggate
{
    public class OrderItem:Entity
    {
        public string ProductId { get;private set; }
        public string ProductName { get;private set; }
        public string PictureUrl { get;private set; }
        public decimal Price { get;private set; }
        public OrderItem(string productId, string productName, string pictureUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
        }
        public void UpdateOrderItem(string productName,string pictureUrl,decimal price)
        {
            ProductName = productName;
            Price = price;
            PictureUrl = pictureUrl;
        }
    }
}
