using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataTypesWordpress
{
    public class WPOrder
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime OrderDate { get; set; }
        public string Telephone { get; set; }
        public double OrderValue { get; set; }
        public DateTime Modified { get; set; }
        public string Mail { get; set; }
        public string CustomerNotes { get; set; }
        public string OrderStatus { get; set; }
    }
}
