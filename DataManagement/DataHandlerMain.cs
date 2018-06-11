using DataManagement.DataBases;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagement.SharedTypeConverter;

namespace DataManagement
{
    public class DataHandlerMain
    {
        //use SharedTypeConverter for converting from DataBaseClasses to SharedDataTypes,
        //it is static so you don't need to initialize it for usage
        SharedConverter converter = new SharedConverter();

        ChocolateCustomizerEntities mainDb = new ChocolateCustomizerEntities();

        #region GiveMeAll Queries



        public List<SharedDataTypes.Order> QueryOrders()
        {
            List<SharedDataTypes.Order> tempSharedOrders = new List<SharedDataTypes.Order>();

            foreach (var item in mainDb.Orders.Select(p => p).ToList())
            {
                tempSharedOrders.Add(converter.ConvertToSharedOrder(item));
            }

            foreach (var tempOrder in tempSharedOrders)
            {


                foreach (var item in mainDb.OrderContents.Where(p=>p.Order_ID.Equals(tempOrder.OrderId)).Select(p=>p).ToList())
                {
                    //tempOrder.Content.Add(converter.ConvertToShared);
                }
            }
            return tempSharedOrders;
        }

        public List<SharedDataTypes.Chocolate> QueryChocolatesWithIngredients()
        {
            List<SharedDataTypes.Chocolate> sharedChocolates = new List<SharedDataTypes.Chocolate>();

            foreach (var choco in mainDb.Chocolates.Select(p => p).ToList())
            {
                sharedChocolates.Add(converter.ConvertToSharedChocolate(choco));
            }


            foreach (var tempChoco in sharedChocolates)
            {
                tempChoco.Ingredients = QueryIngredientsByChocolateId(tempChoco.ChocolateId);
            }
            return sharedChocolates;
        }

        public List<SharedDataTypes.Ingredient> QueryIngredientsByChocolateId(Guid Id)
        {
            List<SharedDataTypes.Ingredient> sharedIngredients = new List<SharedDataTypes.Ingredient>();

            foreach (var item in mainDb.Ingredients.Where(p => p.Chocolates.Count(x => x.ID_Chocolate.Equals(Id)) > 0).ToList())
            {
                sharedIngredients.Add(converter.ConvertToSharedIngredient(item));
            }
            return sharedIngredients;
        }


        public List<SharedDataTypes.Shape> QueryShapes()
        {
            int i = 0;
            var shapes = mainDb.Shapes.Select(p => new SharedDataTypes.Shape()
            {
                ShapeId = p.ID_Shape,
                Name = p.Name,
                //Image = new Uri(p.Image)
            }).ToList();

            //not sure if the best workaround
            var images = mainDb.Shapes.Select(p => p.Image).ToList();

            foreach (var item in shapes)
            {
                item.Image = new Uri(images[i]);
                i++;
            }

            return shapes;
        }

        public List<SharedDataTypes.Wrapping> QueryWrappings()
        {
            List<SharedDataTypes.Wrapping> sharedWrappings = new List<SharedDataTypes.Wrapping>();

            foreach (var item in mainDb.Wrappings.Select(p => p).ToList())
            {
                sharedWrappings.Add(converter.ConvertToSharedWrapping(item));
            }
            return sharedWrappings;
        }

        public List<SharedDataTypes.Ingredient> QueryIngredients()
        {
            List<SharedDataTypes.Ingredient> sharedIngredients = new List<SharedDataTypes.Ingredient>();

            foreach (DataBases.Ingredient item in mainDb.Ingredients.Select(i => i).ToList())
            {
                sharedIngredients.Add(converter.ConvertToSharedIngredient(item));
            }
            return sharedIngredients;
        }

        public List<string> QueryOrderStates()
        {
            return mainDb.OrderStatus.Select(p => p.StatusDescription).ToList();
        }

        #endregion


        #region INSERT METHODS
        public bool InsertShape(SharedDataTypes.Shape shape)
        {
            mainDb.Shapes.Add(new DataBases.Shape()
            {
                ID_Shape = shape.ShapeId,
                Name = shape.Name,
                Image = shape.Image.ToString()
            });

            return mainDb.SaveChanges() == 1;
        }

        public bool InsertWrapping(SharedDataTypes.Wrapping wrapping)
        {
            mainDb.Wrappings.Add(new DataBases.Wrapping()
            {
                ID_Wrapping = wrapping.WrappingId,
                Name = wrapping.Name,
                Price = wrapping.Price,
                Image = wrapping.Image.ToString()
            });
            return mainDb.SaveChanges() == 1;
        }

        public bool InsertIngredient(SharedDataTypes.Ingredient newIngredient)
        {

            mainDb.Ingredients.Add(new DataBases.Ingredient()
            {
                ID_Ingredients = newIngredient.IngredientId,
                Name = newIngredient.Name,
                Description = newIngredient.Description,
                Price = newIngredient.Price,
                Availability = newIngredient.Available,
                Type = newIngredient.Type,
                UnitType = newIngredient.UnitType,
                ModifyDate = newIngredient.Modified
            });
            return mainDb.SaveChanges() > 0;
        }
        #endregion

        #region UPDATE METHODS
        public bool UpdateIngredient(SharedDataTypes.Ingredient item)
        {
            var temp = mainDb.Ingredients.Where(i => i.ID_Ingredients == item.IngredientId).Select(j => j).First();
            temp.Name = item.Name;
            temp.Description = item.Description;
            temp.Price = item.Price;
            temp.Availability = item.Available;
            temp.Type = item.Type;
            temp.UnitType = item.UnitType;
            temp.ModifyDate = DateTime.Now;
            return mainDb.SaveChanges() > 0;
        }
        #endregion
    }
}