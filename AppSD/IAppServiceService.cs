using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace AppSD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAppServiceService" in both code and config file together.
    [ServiceContract]
    public interface IAppServiceService
    {
        #region HEAD
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "REST_Tester/{id}-{name}")]
        string REST_Tester(string id, string name);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "IsAlive")]
        bool IsAlive();
        #endregion

        #region QUERIES
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "QueryOrders")]
        List<Order> QueryOrders();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "QueryIngredients")]
        List<Ingredient> QueryIngredients();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "QueryShapes")]
        List<Shape> QueryShapes();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "QueryWrappings")]
        List<Wrapping> QueryWrappings();
        #endregion

        #region UPDATE METHODS
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateIngredient"),]
        bool UpdateIngredient(Ingredient item);
        #endregion


    }
}
