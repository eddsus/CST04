using System;

namespace SharedDataTypes
{
    public class OrderStatus
    {
        public Guid OrderStatusId { get; set; }
        public string Decription { get; set; }
        public DateTime? Modified { get; set; }

    }
}