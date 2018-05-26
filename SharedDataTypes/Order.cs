using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataTypes
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public string Note { get; set; }
        public List<OrderContent> Content { get; set; }
    }
}
