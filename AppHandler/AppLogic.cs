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

        public List<Ingredient> QueryAllIngredients()
        {
            return mainDh.QueryAllIngredients();
        }

    }
}
