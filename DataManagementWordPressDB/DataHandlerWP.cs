using DataManagementWordPressDB.DbModel;
using SharedDataTypesWordpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagementWordPressDB
{
    public class DataHandlerWP
    {

        WordPressEntities db = new WordPressEntities();


        public List<WPOrder> QueryAllOrders()
        {
            return (from a in db.wp_posts
                    join b in db.wp_postmeta on a.ID equals b.post_id
                    where a.post_type.Contains("shop_order")
                    select new WPOrder
                    {
                        ID = a.ID,
                        post_status = a.post_status,
                        post_title = a.post_title,
                        post_date = a.post_date
                        
                    }).ToList();
        }
    }
}
