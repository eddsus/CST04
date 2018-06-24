using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataTypesWordpress
{
    public class WPPosts
    {
        public decimal ID { get; set; }
        public decimal post_author { get; set; }
        public System.DateTime post_date { get; set; }
        public System.DateTime post_date_gmt { get; set; }
        public string post_content { get; set; }
        public string post_title { get; set; }
        public string post_excerpt { get; set; }
        public string post_status { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public string post_password { get; set; }
        public string post_name { get; set; }
        public string to_ping { get; set; }
        public string pinged { get; set; }
        public System.DateTime post_modified { get; set; }
        public System.DateTime post_modified_gmt { get; set; }
        public string post_content_filtered { get; set; }
        public decimal post_parent { get; set; }
        public string guid { get; set; }
        public int menu_order { get; set; }
        public string post_type { get; set; }
        public string post_mime_type { get; set; }
        public long comment_count { get; set; }

        public List<WPOrderItem> OrderItems { get; set; }
        
    }
}
