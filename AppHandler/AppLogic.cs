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

        public List<SharedDataTypes.Rating> QueryRatings()
        {
            return mainDh.QueryRatings();
        }

        public bool ChangeStateOfAnOrder(Guid orderId, SharedDataTypes.OrderStatus status)
        {
            return mainDh.ChangeStateOfAnOrder(orderId, status);
        }

        public List<OrderContentChocolate> QueryOrdersContentChocolate(string orderId)
        {
            return mainDh.QueryOrdersContentChocolate(orderId);
        }

        public List<OrderContentPackage> QueryOrdersContentPackage(string orderId)
        {
            return mainDh.QueryOrdersContentPackage(orderId);
        }

        public List<Ingredient> QueryIngredients()
        {
            return mainDh.QueryIngredients();
        }

        public List<Ingredient> QueryIngredientsByChocolateId(Guid id)
        {
            return mainDh.QueryIngredientsByChocolateId(id);
        }

        public List<Shape> QueryShapes()
        {
            return mainDh.QueryShapes();
        }
        public List<Wrapping> QueryWrappings()
        {
            return mainDh.QueryWrappings();
        }

        public List<OrderStatus> QueryOrderStates()
        {
            return mainDh.QueryOrderStates();
        }

        public List<Chocolate> QueryChocolatesWithIngredients()
        {
            return mainDh.QueryChocolatesWithIngredients();

        }

        public bool UpdateChocolate(Chocolate c)
        {
            return mainDh.UpdateChocolate(c);
        }

        public bool UpdatePackage(Package p)
        {
            return mainDh.UpdatePackage(p);
        }

        public bool UpdateIngredient(Ingredient item)
        {
            //::TODO:: Also update Frontend database
            return mainDh.UpdateIngredient(item);
        }
    }
}
