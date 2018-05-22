using DataManagement;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHandler
{
    public class AppLogic
    {
        DataHandlerMain mainDh = new DataHandlerMain();
        //add other dbHandlers here
        public List<Order> QueryOrders()
        {
            return mainDh.QueryOrders();
        }

        public List<Ingredient> QueryIngredients()
        {
            return mainDh.QueryIngredients();
        }
        public List<Shape> QueryShapes()
        {
            return mainDh.QueryShapes();
        }
        public List<Wrapping> QueryWrappings()
        {
            return mainDh.QueryWrappings();
        }


    }
}
