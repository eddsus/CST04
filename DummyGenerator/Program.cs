
using DataManagement;
using Messaging;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            DataHandlerMain mainDh = new DataHandlerMain();
            SyncMessageQueue<string> mq = new SyncMessageQueue<string>("testChannel");

            #region Add Ingredient to DB
            //Ingredient almonds = new Ingredient()
            //{
            //    IngredientId = Guid.NewGuid(),
            //    Name = "INSERT NEW NAME BEFORE YOU RUN!!!",
            //    Description = "The coconut tree is a member of the family Arecaceae and the only species of the genus Cocos. The term coconut can refer to the whole coconut palm or the seed, or the fruit, which, botanically, is a drupe, not a nut. The spelling cocoanut is an archaic form of the word.",
            //    Available = true,
            //    Price = 0.30,
            //    Type = "Filling",
            //    UnitType = "g"
            //};

            //bool success = mainDh.InsertIngredient(almonds);

            //if (success)
            //{
            //    var result = mainDh.QueryAllIngredients();
            //}
            #endregion

            mq.Send("Test message");

            Console.ReadLine();
        }
    }
}
