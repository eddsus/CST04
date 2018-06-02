
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
            Ingredient almonds = new Ingredient()
            {
                IngredientId = Guid.NewGuid(),
                Name = "5 Banana King 4",
                Description = "The inglorious Banana is back again and again",
                Available = true,
                Price = 0.30,
                Type = "Filling",
                UnitType = "g",
                Modified = DateTime.Now
            };

            bool success = mainDh.InsertIngredient(almonds);

            if (success)
            {
                var result = mainDh.QueryIngredients();
            }
            #endregion

            #region Add a wrapping to the DB
            //Wrapping wrap = new Wrapping()
            //{
            //    WrappingId = Guid.NewGuid(),
            //    Name = "wrap no. 1",
            //    Price = 5,
            //    Image = new Uri("https://images-na.ssl-images-amazon.com/images/I/51XG6jlBOIL._SY355_.jpg")
            //};

            //mainDh.InsertWrapping(wrap);
            #endregion


            #region Add a shape to the DB
            //Shape shape = new Shape()
            //{
            //    ShapeId=Guid.NewGuid(),
            //    Name="Shape no. 1",
            //    Image= new Uri("https://image.freepik.com/free-icon/heart-shape-silhouette_318-41967.jpg")
            //};

            //mainDh.InsertShape(shape);
            #endregion

            //mq.Send("Test message");
            Console.ReadLine();
        }
    }
}
