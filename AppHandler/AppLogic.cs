using DataManagement;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPDataRepo;

namespace AppHandler
{
    public class AppLogic
    {
        //This Class gives back Data from the main Server db and makes sure that when a Insert Update or delete method 
        //is performed in the Server db that statement is also passed on to the Frontend db
        DataHandlerMain mainDh = new DataHandlerMain();
        WPDataHandler wpDh = new WPDataHandler();

        #region QUERIES
        public List<Order> QueryOrders()
        {
            return mainDh.QueryOrders();
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
        #endregion

        #region INSERTS

        public bool InsertPackage(Package p) => mainDh.InsertPackage(p) && wpDh.AddPackage(p) > 0;

        public bool InsertChocolate(Chocolate c) => mainDh.InsertChocolate(c) && wpDh.AddProduct(c) > 0;

        public bool InsertIngredient(Ingredient i) => mainDh.InsertIngredient(i) && wpDh.AddIngredientWP(i) > 0;
        #endregion

        #region UPDATES
        public bool UpdateOrder(SharedDataTypes.Order o) => mainDh.UpdateOrder(o) && wpDh.UpdateOrder(o) > 0;

        public bool UpdateChocolate(Chocolate c) => mainDh.UpdateChocolate(c) && wpDh.UpdateChocolate(c) > 0;

        public bool UpdatePackage(Package p) => mainDh.UpdatePackage(p) && wpDh.UpdatePackage(p);

        public bool UpdateIngredient(Ingredient i) => mainDh.UpdateIngredient(i) && wpDh.UpdateIngredient(i);

        #endregion

        #region DELETES
        public bool DeleteOrderContentByContentId(string ocId, string type) => mainDh.DeleteOrderContentByContentId(ocId, type) && wpDh.DeleteOrderContentByContentId(ocId, type);
        #endregion
    }
}
