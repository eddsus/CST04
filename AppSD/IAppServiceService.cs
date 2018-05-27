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
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "REST_Tester/{id}-{name}")]
        string REST_Tester(string id, string name);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "IsAlive")]
        bool IsAlive();

        [OperationContract]
        List<Order> QueryOrders();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "QueryIngredients")]
        List<Ingredient> QueryIngredients();

        [OperationContract]
        List<Shape> QueryShapes();

        [OperationContract]
        List<Wrapping> QueryWrappings();



    }
}
