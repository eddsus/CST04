using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SharedDataTypes;
using AppHandler;

namespace AppSD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AppServiceService" in both code and config file together.
    public class AppServiceService : IAppServiceService
    {
        public bool IsAlive()
        {
            return true;
        }

        public List<Ingredient> QueryIngredients()
        {
            return new AppLogic().QueryIngredients();
        }

        public List<Order> QueryOrders()
        {
            return new AppLogic().QueryOrders();
        }

        public List<Shape> QueryShapes()
        {
            return new AppLogic().QueryShapes();
        }

        public List<Wrapping> QueryWrappings()
        {
            return new AppLogic().QueryWrappings();
        }
    }
}
