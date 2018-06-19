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
        public SharedDataTypes.Address ConvertToSharedAddress(DataBases.Address a)
        {
            return new SharedDataTypes.Address()
            {
                AdressId = a.ID_Address,
                City = a.City,
                HouseNumber = a.HouseNumber,
                StreetName = a.StreetName,
                Zip = a.ZIP
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
                    Ingredients = ConvertToSharedIngredientList(choco.Ingredients),
                    Available = choco.Available,
                    CustomStyle = ConvertToSharedCustomStyle(choco.CustomStyle),
                    Wrapping = ConvertToSharedWrapping(choco.Wrapping),
                    Modified = choco.ModifyDate,
                    Ratings = ConvertToSharedRatings(choco.Rating),// No ratings => Leads to stack overflow
                    CreatedBy = ConvertToSharedCustomer(choco.Customer)
                };
            }
            else
            {
                return null;
            }
        }

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
            var t1 = dbOrderContent.Select(oc => new OrderContentChocolate()
            {
                OrderContentId = oc.ID_OrderContent,
                Chocolate = ConvertToSharedChocolate(oc.OrderContent_has_Chocolate.First().Chocolate),
                Amount = oc.OrderContent_has_Chocolate.First().Amount
            }).ToList();
            tempSharedOrderContent.AddRange(t1);
            return tempSharedOrderContent;
        }

        internal List<SharedDataTypes.OrderContentPackage> ConvertOrdersContentPackage(List<DataBases.OrderContent> dbOrderContent)
        {
            List<SharedDataTypes.OrderContentPackage> tempSharedOrderContent = new List<SharedDataTypes.OrderContentPackage>();
            var t2 = dbOrderContent.Select(oc => new OrderContentPackage()
            {
                OrderContentId = oc.ID_OrderContent,
                Package = ConvertToSharedPackage(oc.OrderContent_has_Package.First().Package),
                Amount = oc.OrderContent_has_Chocolate.First().Amount
            }).ToList();
            tempSharedOrderContent.AddRange(t2);
            return tempSharedOrderContent;
        }

        public SharedDataTypes.Customer ConvertToSharedCustomer(DataBases.Customer c)
        {
            return new SharedDataTypes.Customer()
            {
                CustomerId = c.ID_Customer,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = ConvertToSharedAddress(c.Address.First()),
                Mail = c.Mail,
                PhoneNumber = c.PhoneNumber
            };
        }

        private SharedDataTypes.CustomStyle ConvertToSharedCustomStyle(DataBases.CustomStyle cs)
        {
            return new SharedDataTypes.CustomStyle
            {
                CustomStyleId = cs.ID_CustomStyle,
                Name = cs.Name,
                Description = cs.Description
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
                Note = o.Note
                //Content = this has to stay empty or else everything will be fucked up
            };
        }

        public SharedDataTypes.OrderStatus ConvertToSharedOrderStatus(DataBases.OrderStatus os)
        {
            return new SharedDataTypes.OrderStatus()
            {
                OrderStatusId = os.ID_OrderStatus,
                Decription = os.StatusDescription
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
                        Comment = item.Comment,
                        Customer = ConvertToSharedCustomer(item.Customer),
                        Published = item.Published
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
                        Published = item.Published
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
                Image = s.Image
            };
        }

        public SharedDataTypes.Wrapping ConvertToSharedWrapping(DataBases.Wrapping w)
        {
            return new SharedDataTypes.Wrapping
            {
                WrappingId = w.ID_Wrapping,
                Name = w.Name,
                Price = w.Price,
                Image = w.Image
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
                ModifyDate = i.Modified
            };
        }
        //public SharedDataTypes.OrderContent ConvertToSharedPackageOrderContentPackage(DataBases.Package p)
        //{
        //    return new OrderContentPackage
        //    {
        //        OrderContentId = p.ID_Package,
        //        Package = ConvertToSharedPackage(p),
        //        Amount = p.OrderContent_has_Package.Select(q => q.Amount).First()
        //    };
        //}
        //public SharedDataTypes.OrderContent ConvertToSharedChocolateOrderContentChocolate(DataBases.Chocolate choco)
        //{
        //    return new OrderContentChocolate
        //    {
        //        OrderContentId = choco.ID_Chocolate,
        //        Chocolate = ConvertToSharedChocolate(choco),
        //        Amount = choco.OrderContent_has_Chocolate.Select(p => p.Amount).First()
        //    };
        //}
        //public DataBases.Chocolate ConvertToDBChoco(SharedDataTypes.Chocolate c)
        //{
        //    return new DataBases.Chocolate
        //    {
        //        ID_Chocolate = c.ChocolateId,
        //        Name = c.Name,
        //        Description = c.Description,
        //        Available = c.Available,
        //        Shape_ID = c.Shape.ShapeId,
        //        CustomStyle_ID = c.CustomStyle.CustomStyleId,
        //        Image = c.Image,
        //        Creator_Customer_ID = c.CreatedBy.CustomerId,
        //        ModifyDate = c.Modified.GetValueOrDefault(),
        //        WrappingID = c.Wrapping.WrappingId
        //    };
        //}
        //public DataBases.Package ConvertToDBPackage(SharedDataTypes.Package p)
        //{
        //    return new DataBases.Package
        //    {
        //        ID_Package = p.PackageId,
        //        Name = p.Name,
        //        Descripton = p.Description,
        //        WrappingID = p.Wrapping.WrappingId,
        //        Availability = p.Available,
        //        Customer_ID = p.Customer.CustomerId,
        //        Image = p.Image,
        //        ModifyDate = p.Modified.GetValueOrDefault(),
        //    };
        //}
    }
}
