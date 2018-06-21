using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataTypesWordpress
{
    public class WPOrder
    {

        public decimal ID { get; set; }
        public System.DateTime post_date { get; set; }
        public string post_title { get; set; }
        public string post_status { get; set; }
        public string meta_value { get; set; }

    }
}
