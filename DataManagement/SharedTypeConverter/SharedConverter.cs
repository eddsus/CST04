using DataManagement.DataBases;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.SharedTypeConverter
{
    public class SharedConverter
    {
        #region toSharedObject
        public SharedDataTypes.Address ConvertToSharedAddress(DataBases.Address a)
        {
            return new SharedDataTypes.Address()
            {
                AdressId = a.ID_Address,
                City = a.City,
                HouseNumber = a.HouseNumber,
                StreetName = a.StreetName,
                Zip = a.ZIP,
                Modified = a.ModifyDate
            };
        }

        public SharedDataTypes.Chocolate ConvertToSharedChocolate(DataBases.Chocolate choco)
        {
            if (choco != null)
            {
                return new SharedDataTypes.Chocolate()
                {
                    ChocolateId = choco.ID_Chocolate,
                    Name = choco.Name,
                    Description = choco.Description,
                    Shape = ConvertToSharedShape(choco.Shape),
                    Image = choco.Image,
                    Ingredients = new List<SharedDataTypes.Ingredient>(),
                    Available = choco.Available,
                    CustomStyle = ConvertToSharedCustomStyle(choco.CustomStyle),
                    Wrapping = ConvertToSharedWrapping(choco.Wrapping),
                    Modified = choco.ModifyDate,
                    Ratings = ConvertToSharedRatings(choco.Rating),
                    CreatedBy = ConvertToSharedCustomer(choco.Customer)
                };
            }
            else
            {
                return null;
            }
        }

        //no reference??
        private List<SharedDataTypes.Ingredient> ConvertToSharedIngredientList(ICollection<DataBases.Ingredients> ingredients)
        {
            var tempIngredients = new List<SharedDataTypes.Ingredient>();
            foreach (var item in ingredients)
            {
                tempIngredients.Add(new SharedDataTypes.Ingredient()
                {
                    IngredientId = item.ID_Ingredients,
                    Name = item.Name,
                    Description = item.Description,
                    Type = item.Type,
                    UnitType = item.UnitType,
                    Price = item.Price,
                    Available = item.Availability,
                    Modified = item.ModifyDate
                });

            }
            return tempIngredients;
        }

        internal List<SharedDataTypes.OrderContentChocolate> ConvertOrdersContentChocolate(List<DataBases.OrderContent> dbOrderContent)
        {
            List<SharedDataTypes.OrderContentChocolate> tempSharedOrderContent = new List<SharedDataTypes.OrderContentChocolate>();
            foreach (var item in dbOrderContent)
            {
                if (item.OrderContent_has_Chocolate.Count > 0)
                    tempSharedOrderContent.Add(new OrderContentChocolate()
                    {
                        OrderContentId = item.ID_OrderContent,
                        Chocolate = ConvertToSharedChocolate(item.OrderContent_has_Chocolate.First().Chocolate),
                        Amount = item.OrderContent_has_Chocolate.First().Amount,
                        Modified = item.ModifyDate
                    });
            }
            return tempSharedOrderContent;
        }

        internal List<SharedDataTypes.OrderContentPackage> ConvertOrdersContentPackage(List<DataBases.OrderContent> dbOrderContent)
        {
            List<SharedDataTypes.OrderContentPackage> tempSharedOrderContent = new List<SharedDataTypes.OrderContentPackage>();
            foreach (var item in dbOrderContent)
            {
                if (item.OrderContent_has_Package.Count > 0)
                    tempSharedOrderContent.Add(new OrderContentPackage()
                    {
                        OrderContentId = item.ID_OrderContent,
                        Package = ConvertToSharedPackage(item.OrderContent_has_Package.First().Package),
                        Amount = item.OrderContent_has_Package.First().Amount,
                        Modified = item.ModifyDate
                    });
            }
            return tempSharedOrderContent;
        }

        public SharedDataTypes.Customer ConvertToSharedCustomer(DataBases.Customer c)
        {
            return new SharedDataTypes.Customer()
            {
                CustomerId = c.ID_Customer,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = ConvertToSharedAddress(c.Customer_has_Address.Select(a => a.Address).First()),
                Mail = c.Mail,
                PhoneNumber = c.PhoneNumber,
                Modified = c.ModifyDate
            };
        }

        public SharedDataTypes.CustomStyle ConvertToSharedCustomStyle(DataBases.CustomStyle cs)
        {
            return new SharedDataTypes.CustomStyle
            {
                CustomStyleId = cs.ID_CustomStyle,
                Name = cs.Name,
                Description = cs.Description,
                Modified = cs.ModifyDate
            };
        }


        public SharedDataTypes.Ingredient ConvertToSharedIngredient(DataBases.Ingredients i)
        {
            return new SharedDataTypes.Ingredient
            {
                IngredientId = i.ID_Ingredients,
                Name = i.Name,
                Description = i.Description,
                Available = i.Availability,
                Type = i.Type,
                Price = i.Price,
                UnitType = i.UnitType,
                Modified = i.ModifyDate
            };
        }

        public SharedDataTypes.Order ConvertToSharedOrder(DataBases.Order o)
        {
            return new SharedDataTypes.Order()
            {
                OrderId = o.ID_Order,
                DateOfOrder = o.DateOfOrder,
                DateOfDelivery = o.DateOfDelivery,
                Customer = ConvertToSharedCustomer(o.Customer),
                Status = ConvertToSharedOrderStatus(o.OrderStatus),
                Note = o.Note,
                Modified = o.ModifyDate,
                
                //Content = this has to stay empty or else everything will be fucked up
            };
        }

        public SharedDataTypes.OrderStatus ConvertToSharedOrderStatus(DataBases.OrderStatus os)
        {
            return new SharedDataTypes.OrderStatus()
            {
                OrderStatusId = os.ID_OrderStatus,
                Decription = os.StatusDescription,
                Modified = os.ModifyDate
            };
        }

        public SharedDataTypes.Package ConvertToSharedPackage(DataBases.Package p)
        {
            if (p != null)
            {
                return new SharedDataTypes.Package
                {
                    PackageId = p.ID_Package,
                    Name = p.Name,
                    Description = p.Descripton,
                    Image = p.Image,
                    Customer = ConvertToSharedCustomer(p.Customer),
                    Modified = p.ModifyDate,
                    Ratings = ConvertToSharedRatings(p.Rating),
                    Wrapping = ConvertToSharedWrapping(p.Wrapping1),
                    Available = p.Availability,
                    Chocolates = ConvertToSharedChocolateList(p.Package_has_Chocolate.Select(c => c).ToList())
                };
            }
            else
            {
                return null;
            }
        }

        private List<SharedDataTypes.Chocolate> ConvertToSharedChocolateList(List<Package_has_Chocolate> list)
        {
            var temp = new List<SharedDataTypes.Chocolate>();
            foreach (var item in list)
            {
                temp.Add(ConvertToSharedChocolate(item.Chocolate));
            }
            return temp;
        }

        //      chocolate/package wont be saved so that we can avoid stack overflow ex, might by problematic
        public List<SharedDataTypes.Rating> ConvertToSharedRatings(ICollection<DataBases.Rating> r)
        {

            List<SharedDataTypes.Rating> tempRatings = new List<SharedDataTypes.Rating>();

            foreach (var item in r)
            {

                if (item.Chocolate != null)
                {
                    tempRatings.Add(new SharedDataTypes.Rating
                    {
                        RatingId = item.ID_Rating,
                        Value = item.Value,
                        Date = item.Date,
                        //Chocolate = ConvertToSharedChocolate(item.Chocolate),
                        ProductName = item.Chocolate.Name,
                        ProductId = item.Chocolate.ID_Chocolate,
                        Comment = item.Comment,
                        Customer = ConvertToSharedCustomer(item.Customer),
                        Published = item.Published,
                        Modified = item.ModifyDate,
                        type = true
                    });
                }
                else if (item.Package != null)
                {
                    tempRatings.Add(new SharedDataTypes.Rating
                    {
                        RatingId = item.ID_Rating,
                        Value = item.Value,
                        Date = item.Date,
                        Comment = item.Comment,
                        Customer = ConvertToSharedCustomer(item.Customer),
                        //Package = ConvertToSharedPackage(item.Package),
                        ProductName = item.Package.Name,
                        ProductId = item.Package.ID_Package,
                        Published = item.Published,
                        Modified = item.ModifyDate,
                        type = false
                    });
                }
            }
            return tempRatings;
        }


        public SharedDataTypes.Shape ConvertToSharedShape(DataBases.Shape s)
        {
            return new SharedDataTypes.Shape
            {
                ShapeId = s.ID_Shape,
                Name = s.Name,
                Image = s.Image,
                Modified = s.ModifyDate
            };
        }

        public SharedDataTypes.Wrapping ConvertToSharedWrapping(DataBases.Wrapping w)
        {
            return new SharedDataTypes.Wrapping
            {
                WrappingId = w.ID_Wrapping,
                Name = w.Name,
                Price = w.Price,
                Image = w.Image,
                Modified = w.ModifyDate
            };
        }

        #endregion





        #region ToDBObject
        internal Package_has_Chocolate ConvertToDBPackageHasChoco(Guid chocoId, Guid packageId)
        {
            return new Package_has_Chocolate
            {
                Chocolate_ID = chocoId,
                Package_ID = packageId,
                ModifyDate = DateTime.Now
            };
        }

        internal Chocolate_has_Ingridients ConvertToDBChocolateHasIngredients(Guid chocolateId, Guid ingredientId)
        {
            return new Chocolate_has_Ingridients {
                Chocolazte_ID=chocolateId,
                Ingerdient_ID=ingredientId,
                ModifyDate=DateTime.Now
            };
        }

        public DataBases.Shape ConvertToDBShape(SharedDataTypes.Shape shape)
        {
            return new DataBases.Shape
            {
                ID_Shape = shape.ShapeId,
                Name = shape.Name,
                Image = shape.Image,
                ModifyDate=DateTime.Now
            };
        }

        public DataBases.Wrapping ConvertToDBWrapping(SharedDataTypes.Wrapping w)
        {
            return new DataBases.Wrapping
            {
                ID_Wrapping = w.WrappingId,
                Name = w.Name,
                Price = w.Price,
                Image = w.Image,
                ModifyDate = DateTime.Now
            };
        }
        public DataBases.Ingredients ConvertToDBIngredient(SharedDataTypes.Ingredient i)
        {
            return new DataBases.Ingredients
            {
                ID_Ingredients = i.IngredientId,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                Type = i.Type,
                UnitType = i.UnitType,
                Availability = i.Available,
                ModifyDate = DateTime.Now
            };
        }

        public DataBases.Chocolate ConvertToDBChoco(SharedDataTypes.Chocolate c)
        {
            return new DataBases.Chocolate
            {
                ID_Chocolate = Guid.NewGuid(),
                Name = c.Name,
                Description = c.Description,
                Available = c.Available,
                Shape_ID = c.Shape.ShapeId,
                CustomStyle_ID = c.CustomStyle.CustomStyleId,
                Image = c.Image,
                Creator_Customer_ID = c.CreatedBy.CustomerId,
                ModifyDate = DateTime.Now,
                WrappingID = c.Wrapping.WrappingId,
            };
        }
        public DataBases.Package ConvertToDBPackage(SharedDataTypes.Package p)
        {
            return new DataBases.Package
            {
                ID_Package = Guid.NewGuid(),
                Name = p.Name,
                Descripton = p.Description,
                WrappingID = p.Wrapping.WrappingId,
                Availability = p.Available,
                Customer_ID = p.Customer.CustomerId,
                Image = p.Image,
                ModifyDate = DateTime.Now,
            };
        }
        #endregion
    }
}
