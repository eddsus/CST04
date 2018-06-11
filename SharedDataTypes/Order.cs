using System;
using System.Collections.Generic;

namespace SharedDataTypes
{
    public class Order
    {
        private Order p;

        public Order()
        {

        }

        public Order(Order p)
        {
            if (p != null)
            {
                OrderId = p.OrderId;
                DateOfOrder = p.DateOfOrder;
                DateOfDelivery = p.DateOfDelivery;
                Status = p.Status;
                Customer = p.Customer;
                Note = p.Note;
                Content = p.Content;
            }
        }

        public string OrderId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public string Note { get; set; }
        public List<OrderContent> Content { get; set; }
    }
}
