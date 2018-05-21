using DataManagement.DataBases;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement
{
    public class DataHandlerMain
    {
        ChocolateCustomizerEntities mainDb = new ChocolateCustomizerEntities();

        public List<Ingredient> QueryAllIngredients()
        {
            return mainDb.Ingredients.Select(i => new Ingredient()
            {
                IngredientId = i.ID_Ingredients,
                Description = i.Description,
                Name = i.Name,
                Price = i.Price,
                Type = i.Type,
                UnitType = i.UnitType,
                //Available = i.Availability
            }).ToList();
        }

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
                UnitType = newIngredient.UnitType
            });
            return mainDb.SaveChanges() > 0;
        }


        public List<SharedDataTypes.Order> QueryOrders()
        {

            var orders = mainDb.Order.Select(p => new SharedDataTypes.Order()
            {
                OrderId = p.ID_Order,
                DateOfOrder = p.DateOfOrder,
                DateOfDelivery = p.DateOfDelivery,
                Customer = new SharedDataTypes.Customer()
                {
                    CustomerId = p.Customer.ID_Customer,
                    FirstName = p.Customer.FirstName,
                    LastName = p.Customer.LastName,
                    Address = new SharedDataTypes.Address()
                    {
                        //kann die Attributen von Address nicht zugreifen
                        AdressId = Guid.NewGuid(),
                        City = "asdf",
                        HouseNumber = 01,
                        StreetName = "ghjk",
                        Zip = 02
                    },
                    Mail = p.Customer.Mail,
                    PhoneNumber = p.Customer.PhoneNumber,
                },
                Status = new SharedDataTypes.OrderStatus()
                {
                    Decription = p.OrderStatus.StatusDescription
                },
                Note = p.Note,
                Content = new List<SharedDataTypes.OrderContent>(p.OrderContent.Count)
            }).ToList();

            //mainDb.Address.Select(p => new SharedDataTypes.Address() {
            //    AdressId=p.ID_Address,
            //    City=p.City,
            //    HouseNumber=p.HouseNumber,
            //    StreetName=p.StreetName,
            //    Zip=p.ZIP,
            //}).ToList();
            return orders;
        }


        public List<SharedDataTypes.Shape> QueryShapes()
        {
            return mainDb.Shape.Select(p => new SharedDataTypes.Shape()
            {
                ShapeId = p.ID_Shape,
                Name = p.Name,
                Image = new Uri(p.Image)
            }).ToList();
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
            return mainDb.Wrapping.Select(p => new SharedDataTypes.Wrapping()
            {
                WrappingId = p.ID_Wrapping,
                Name = p.Name,
                Price = p.Price,
                Image = new Uri(p.Image)
            }).ToList();
        }

        public bool InserWrapping(SharedDataTypes.Wrapping wrapping)
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
    }
}
