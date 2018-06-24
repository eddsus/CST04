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

        public bool InsertPackage(SharedDataTypes.Package p)
        {
            return mainDh.InsertPackage(p);
        }

        public bool InsertChocolate(SharedDataTypes.Chocolate c)
        {
            return mainDh.InsertChocolate(c);
        }

        public bool InsertIngredient(SharedDataTypes.Ingredient i)
        {
            return mainDh.InsertIngredient(i);
        }

        public List<CustomStyle> QueryCustomStyles()
        {
            return mainDh.QueryCustomStyles();
        }

        public List<SharedDataTypes.Customer> QueryCustomers()
        {
            return mainDh.QueryCustomers();
        }
        public bool UpdateRating(SharedDataTypes.Rating r)
        {
            return mainDh.UpdateRating(r);
        }

        public List<SharedDataTypes.Package> QueryPackagesWithChocolatesAndIngredients()
        {
            return mainDh.QueryPackagesWithChocolatesAndIngredients();
        }

        public List<SharedDataTypes.Rating> QueryRatings()
        {
            return mainDh.QueryRatings();
        }

        public bool UpdateOrder(SharedDataTypes.Order o)
        {
            return mainDh.UpdateOrder(o);
        }

        public List<OrderContentChocolate> QueryOrdersContentChocolate(string orderId)
        {
            return mainDh.QueryOrdersContentChocolate(orderId);
        }
        public bool DeleteOrderContentByContentId(string ocId, string type)
        {
            return mainDh.DeleteOrderContentByContentId(ocId, type);
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

        public Customer QueryCustomerByCustomerId(string id)
        {
            return mainDh.QueryCustomerByCustomerId(id);
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
