using SharedDataTypesWordpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPDataRepo
{
    public class WPDataHandler
    {

        wordpressEntities db = new wordpressEntities();

        public int AddProduct()
        {
            decimal count = db.wp_posts.AsEnumerable().Last().ID + 1;
            decimal mId = db.wp_postmeta.AsEnumerable().Last().meta_id + 1;

            db.wp_posts.Add(new wp_posts()
            {
                ID = count,
                post_type = "product",
                post_status = "publish",
                ping_status = "closed",
                post_content = "",
                post_title = "VS Test Product Insert",
                post_excerpt = "",
                comment_status = "open",
                post_password = "",
                post_name = "VSTestProductInsert",
                to_ping = "",
                pinged = "",
                post_content_filtered = "",
                guid = "http://wi-gate.technikum-wien.at:60335/?post_type=product&#038&p=" + count,
                post_mime_type = "",
                post_date = DateTime.Now,
                post_date_gmt = DateTime.Now,
                post_author = 1

            });

             db.SaveChanges();

            db.wp_postmeta.Add(new wp_postmeta()
            {
                meta_id = mId,
                meta_key = "_regular_price",
                meta_value = "5",
                post_id = db.wp_posts.AsEnumerable().Last().ID 
            });

            db.wp_postmeta.Add(new wp_postmeta()
            {
                meta_id = mId,
                meta_key = "_price",
                meta_value = "5",
                post_id = db.wp_posts.AsEnumerable().Last().ID

            });


            db.wp_postmeta.Add(new wp_postmeta()
            {
                meta_id = mId,
                meta_key = "_stock_status",
                meta_value = "instock",
                post_id = db.wp_posts.AsEnumerable().Last().ID

            });

            db.wp_term_relationships.Add(new wp_term_relationships()
            { 

                object_id = db.wp_posts.AsEnumerable().Last().ID,
                term_order = 0,
                term_taxonomy_id = 2,

            });

            db.wp_term_relationships.Add(new wp_term_relationships()
            {

                object_id = db.wp_posts.AsEnumerable().Last().ID,
                term_order = 0,
                term_taxonomy_id = 15,

            });

            return db.SaveChanges();
        }

        public List<WPPosts> QueryProducts()
        {
            return (from x in db.wp_posts
                    where x.post_type.Contains("product")
                    select new WPPosts()
                    {
                        ID = x.ID,
                        post_title = x.post_title,
                        post_status=x.post_status,
                        comment_status=x.comment_status,
                    }).ToList();
        }

        public List<WPPosts> QueryOpenOrders()
        {

            return (from x in db.wp_posts
                    where x.post_type.Contains("shop_order") 
                    select new WPPosts()
                    {
                        ID = x.ID,
                        post_title = x.post_title,
                        post_status = x.post_status,
                        comment_status = x.comment_status,
                        post_date = x.post_date,
                    }).ToList();
        }




    }
}
