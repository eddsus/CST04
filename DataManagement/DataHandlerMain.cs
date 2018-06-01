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
        public List<Ingredient> QueryIngredients()
        {
            var temp = mainDb.Ingredients.Select(i => new Ingredient()
            {
                IngredientId = i.ID_Ingredients,
                Description = i.Description,
                Name = i.Name,
                Price = i.Price,
                Type = i.Type,
                UnitType = i.UnitType,
                Available = i.Availability,
                DatedModified = i.ModifyDate
            }).ToList();
            return temp;
        }



        public List<SharedDataTypes.Order> QueryOrders()
        {
            List<DataBases.Order> tempDbOrders = new List<DataBases.Order>();
            List<SharedDataTypes.Order> tempSharedOrders = new List<SharedDataTypes.Order>();

            tempDbOrders = mainDb.Order.Select(p => p).ToList();

            foreach (var item in tempDbOrders)
            {
                tempSharedOrders.Add(converter.ConvertToSharedOrder(item));
            }
            return tempSharedOrders;
        }

        public List<SharedDataTypes.Shape> QueryShapes()
        {
            int i = 0;
            var shapes = mainDb.Shape.Select(p => new SharedDataTypes.Shape()
            {
                ShapeId = p.ID_Shape,
                Name = p.Name,
                //Image = new Uri(p.Image)
            }).ToList();

            //not sure if the best workaround
            var images = mainDb.Shape.Select(p => p.Image).ToList();

            foreach (var item in shapes)
            {
                item.Image = new Uri(images[i]);
                i++;
            }

            return shapes;
        }

        public bool InsertShape(SharedDataTypes.Shape shape)
        {
            mainDb.Shape.Add(new DataBases.Shape()
            {
                ID_Shape = shape.ShapeId,
                Name = shape.Name,
                Image = shape.Image.ToString()
            });

            return mainDb.SaveChanges() == 1;
        }

        public List<SharedDataTypes.Wrapping> QueryWrappings()
        {
            var wrappings = mainDb.Wrapping.Select(p => new SharedDataTypes.Wrapping()
            {
                WrappingId = p.ID_Wrapping,
                Name = p.Name,
                Price = p.Price,
                ImgPath = p.Image 
            }).ToList();

            //set Uri in Image
            foreach (var item in wrappings)
            {
                item.Image = new Uri(item.ImgPath);
            }
            return wrappings;
        }

        public bool InsertWrapping(SharedDataTypes.Wrapping wrapping)
        {
            mainDb.Wrapping.Add(new DataBases.Wrapping()
            {
                ID_Wrapping = wrapping.WrappingId,
                Name = wrapping.Name,
                Price = wrapping.Price,
                Image = wrapping.Image.ToString()
            });
            return mainDb.SaveChanges() == 1;
        }
        #endregion

        public bool InsertIngredient(Ingredient newIngredient)
        {

            mainDb.Ingredients.Add(new Ingredients()
            {
                ID_Ingredients = newIngredient.IngredientId,
                Name = newIngredient.Name,
                Description = newIngredient.Description,
                Price = newIngredient.Price,
                Availability = newIngredient.Available,
                Type = newIngredient.Type,
                UnitType = newIngredient.UnitType,
                ModifyDate = newIngredient.DatedModified
            });
            return mainDb.SaveChanges() > 0;
        }

    }
}