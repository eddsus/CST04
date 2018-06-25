
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
        public int AddProduct(Chocolate newChoco)
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

        public int AddPackage(Package p)
        {
            throw new NotImplementedException();
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
                            Name = x.name
                        };

            return query.ToList();
        }

        public List<Rating> QueryRatingWP()
        {
            var query = from x in db.wp_comments
                        select new Rating()
                        {
                            Comment=x.comment_content,
                            Date=x.comment_date,
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
        public bool UpdateIngredient(Ingredient i)
        {
            throw new NotImplementedException();
        }

        public int UpdateChocolate(Chocolate c)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePackage(Package p)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(Order o)
        {
            throw new NotImplementedException();
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
        public bool DeleteOrderContentByContentId(string ocId, string type)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SYNC
        public List<WPOrder> CheckForNewOrders(DateTime dt)
        {
            //get all orders
            return db.wp_posts.Where(x => x.post_type.Contains("shop_order") && x.post_modified > dt).Select(x => 
                new WPOrder()
                {
                    ID = x.ID.ToString(),
                    Firstname = GetFirstnameByPostid(x.ID),
                    Lastname= GetLastnameByPostid(x.ID),
                    OrderValue= GetOrderValueByPostid(x.ID),
                    Telephone= GetTelephoneByPostid(x.ID),
                    Modified=x.post_modified,
                    Mail=GetMailByPostid(x.ID),
                    OrderDate=x.post_date,
                    CustomerNotes=x.post_excerpt,
                    OrderStatus=x.post_status
                }
            ).ToList();
        }

        private string GetMailByPostid(decimal iD)
        {
            var query = (from x in db.wp_postmeta
                         where x.post_id == iD && x.meta_key.Contains("_billing_email")
                         select x).First();

            return query.meta_value;
        }

        private string GetTelephoneByPostid(decimal iD)
        {
            var query = (from x in db.wp_postmeta
                         where x.post_id == iD && x.meta_key.Contains("_billing_phone")
                         select x).First();

            return query.meta_value;
        }
        
        private double GetOrderValueByPostid(decimal iD)
        {
            var query = (from x in db.wp_postmeta
                         where x.post_id == iD && x.meta_key.Contains("_order_total")
                         select x).First();

            return double.Parse(query.meta_value);
        }
        
        private string GetLastnameByPostid(decimal iD)
        {
            var query = (from x in db.wp_postmeta
                         where x.post_id == iD && x.meta_key.Contains("_billing_last_name")
                         select x).First();

            return query.meta_value;
        }

        private string GetFirstnameByPostid(decimal iD)
        {
            var query = (from x in db.wp_postmeta
                         where x.post_id == iD && x.meta_key.Contains("_billing_first_name")
                         select x).First();

            return query.meta_value;
        }

        #endregion
    }
}
