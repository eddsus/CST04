
using SharedDataTypes;
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

        #region ADD
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

        public int AddIngredientWP(Ingredient i)
        {
            db.wp_terms.Add(new wp_terms()
            {
                name = i.Name,
                slug = i.Name.ToLower(),
                term_group = 0
            });

            db.SaveChanges();

            db.wp_term_taxonomy.Add(new wp_term_taxonomy()
            {
                term_id = db.wp_terms.AsEnumerable().Last().term_id,
                count = 1,
                taxonomy = "pa_ingredients",
                parent = 0,
                description = ""

            });

            db.SaveChanges();

            db.wp_term_relationships.Add(new wp_term_relationships()
            {
                object_id = 214,
                term_order = 0,
                term_taxonomy_id = db.wp_term_taxonomy.AsEnumerable().Last().term_id
            });

            return db.SaveChanges();
        }

        public int AddWrappingWP(Ingredient i)
        {
            db.wp_terms.Add(new wp_terms()
            {
                name = i.Name,
                slug = i.Name.ToLower(),
                term_group = 0
            });

            db.SaveChanges();

            db.wp_term_taxonomy.Add(new wp_term_taxonomy()
            {
                term_id = db.wp_terms.AsEnumerable().Last().term_id,
                count = 1,
                taxonomy = "pa_wrapping",
                parent = 0,
                description = ""

            });

            db.SaveChanges();

            db.wp_term_relationships.Add(new wp_term_relationships()
            {
                object_id = 214,
                term_order = 0,
                term_taxonomy_id = db.wp_term_taxonomy.AsEnumerable().Last().term_id
            });

            return db.SaveChanges();
        }
        #endregion

        #region QUERY
        public List<WPPosts> QueryProducts()
        {
            return (from x in db.wp_posts
                    where x.post_type.Contains("product")
                    select new WPPosts()
                    {
                        ID = x.ID,
                        post_title = x.post_title,
                        post_status = x.post_status,
                        comment_status = x.comment_status,
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

        public List<Ingredient> QueryIngedientWP()
        {
            var query = from x in db.wp_terms
                        join y in db.wp_term_taxonomy on x.term_id equals y.term_id
                        where y.taxonomy.Equals("pa_1ingredient")
                        select new Ingredient()
                        {
                            Name = x.name
                        };

            return query.ToList();
        }

        public List<Wrapping> QueryWrappingWP()
        {
            var query = from x in db.wp_terms
                        join y in db.wp_term_taxonomy on x.term_id equals y.term_id
                        where y.taxonomy.Equals("pa_wrapping")
                        select new Wrapping()
                        {
                            //WrappingId = Guid.Parse(x.term_id.ToString()),
                            Name = x.name
                        };

            return query.ToList();
        }
        #endregion

        #region UPDATE
        public int UpdateIngredientAvailibilityWP(Ingredient i)
        {
            var query = (from x in db.wp_terms
                         where x.name.Contains(i.Name)
                         select x).First();

            

            return db.SaveChanges();
        }
        #endregion

        #region DELETE
        public int DeleteIngredientWP(Ingredient i)
        {
            var query = (from x in db.wp_terms
                         where x.term_id.Equals(i.IngredientId)
                         select x).First();

            var query2 = (from x in db.wp_term_taxonomy
                          where x.term_id.Equals(i.IngredientId)
                          select x).First();

            var query3 = (from x in db.wp_term_relationships
                          where x.term_taxonomy_id.Equals(query2.term_taxonomy_id)
                          select x).First();

            db.wp_terms.Remove(query);
            db.wp_term_taxonomy.Remove(query2);
            db.wp_term_relationships.Remove(query3);

            return db.SaveChanges();
        }

        public int DeleteWrappingWP(Wrapping w)
        {
            var query = (from x in db.wp_terms
                         where x.term_id.Equals(w.WrappingId)
                         select x).First();

            var query2 = (from x in db.wp_term_taxonomy
                          where x.term_id.Equals(w.WrappingId)
                          select x).First();

            var query3 = (from x in db.wp_term_relationships
                          where x.term_taxonomy_id.Equals(query2.term_taxonomy_id)
                          select x).First();

            db.wp_terms.Remove(query);
            db.wp_term_taxonomy.Remove(query2);
            db.wp_term_relationships.Remove(query3);

            return db.SaveChanges();
        }
        #endregion

        #region SYNC
        public void CheckForNewOrders(DateTime dt)
        {
            var queryOrder = from x in db.wp_posts
                             where x.post_type.Contains("shop_order") && dt < x.post_modified
                             select x;

            foreach (var item in queryOrder)
            {
                var queryDetails = from x in db.wp_postmeta
                                   where x.post_id == item.ID
                                   select x;
            }
        }
        
        #endregion
    }
}
