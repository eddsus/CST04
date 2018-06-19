﻿using System;
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
        public string REST_Tester(string id, string name)
        {
            return id + " Name: " + name + " Motherfucker!";
        }

        public bool IsAlive()
        {
            return true;
        }

        #region QUERIES
        public List<Ingredient> QueryIngredients()
        {
            return new AppLogic().QueryIngredients();
        }

        public List<Order> QueryOrders()
        {
            return new AppLogic().QueryOrders();
        }

        public List<OrderContentChocolate> QueryOrdersContentChocolate(string orderId)
        {
            return new AppLogic().QueryOrdersContentChocolate(orderId);
        }

        public List<OrderContentPackage> QueryOrdersContentPackage(string orderId)
        {
            return new AppLogic().QueryOrdersContentPackage(orderId);
        }

        public List<Shape> QueryShapes()
        {
            return new AppLogic().QueryShapes();
        }

        public List<Wrapping> QueryWrappings()
        {
            return new AppLogic().QueryWrappings();
        }

        public List<OrderStatus> QueryOrderStates()
        {
            return new AppLogic().QueryOrderStates();
        }
        public List<Chocolate> QueryChocolatesWithIngredients()
        {
            return new AppLogic().QueryChocolatesWithIngredients();
        }

        public List<Ingredient> QueryIngredientsByChocolateId(Guid id)
        {
            return new AppLogic().QueryIngredientsByChocolateId(id);
        }
        public List<Rating> QueryRatings()
        {
            return new AppLogic().QueryRatings();
        }


        #endregion

        #region UPDATE METHODS
        public bool UpdateIngredient(Ingredient item)
        {
            return new AppLogic().UpdateIngredient(item);
        }

        public bool UpdateChocolate(Chocolate item)
        {
            return new AppLogic().UpdateChocolate(item);
        }

        public bool ChangeStateOfAnOrder(Guid orderId, SharedDataTypes.OrderStatus status)
        {
            return new AppLogic().ChangeStateOfAnOrder(orderId, status);
        }

        public bool UpdatePackage(Package item)
        {
            return new AppLogic().UpdatePackage(item);
        }

        #endregion

    }
}
