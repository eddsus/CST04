using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppSD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAppServiceService" in both code and config file together.
    [ServiceContract]
    public interface IAppServiceService
    {
        [OperationContract]
        bool IsAlive();

        [OperationContract]
        List<Ingredient> QueryAllIngredients();
    }
}
