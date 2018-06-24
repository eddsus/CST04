
using SharedDataTypesWordpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPDataRepo;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            wordpressEntities context = new wordpressEntities();
            WPDataHandler dbh = new WPDataHandler();
            var query = from it in context.wp_posts

                        select it;
            WPPosts order;


            foreach (var comp in query) { 
            order = new WPPosts()
            {
                ID = comp.ID,
                post_status = comp.post_status,
                post_date = comp.post_date
            };
            Console.WriteLine("{0} | {1} | {2}", order.ID,order.post_date, order.post_status) ;
        }

            int count = context.wp_posts.Count() + 1;


            Console.WriteLine(dbh.AddProduct());

            Console.ReadLine();

        }
    }
}
