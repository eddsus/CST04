using DataManagementWordPressDB;
using SharedDataTypesWordpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DataHandlerWP dbh = new DataHandlerWP();

            List<WPOrder> list = dbh.QueryAllOrders();

            Console.WriteLine(list);

            Console.ReadLine();

        }
    }
}
