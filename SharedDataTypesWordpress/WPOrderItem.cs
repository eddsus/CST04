using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataTypesWordpress
{
    public class WPOrderItem
    {


        public decimal order_item_id { get; set; }
        public string order_item_name { get; set; }
        public string order_item_type { get; set; }
        public decimal order_id { get; set; }


    }
}
