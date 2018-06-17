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
                Ratings = ConvertToSharedRatings(choco.Ratings),
                CreatedBy = ConvertToSharedCustomer(choco.Customer)
            };
        }

        public SharedDataTypes.Customer ConvertToSharedCustomer(DataBases.Customer c)
        {
            return new SharedDataTypes.Customer()
            {
                CustomerId = c.ID_Customer,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = ConvertToSharedAddress(c.Addresses.First()),
                Mail = c.Mail,
                PhoneNumber = c.PhoneNumber
            };
        }

        public SharedDataTypes.OrderContent ConvertToSharedChocolateOrderContentChocolate(DataBases.Chocolate choco)
        {
            return new OrderContentChocolate
            {
                OrderContentId = choco.ID_Chocolate,
                Chocolate = ConvertToSharedChocolate(choco),
                Amount = choco.OrderContent_has_Chocolate.Select(p => p.Amount).First()
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

        public SharedDataTypes.Ingredient ConvertToSharedIngredient(DataBases.Ingredient i)
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
                Status = ConvertToSharedOrderStatus(o.OrderStatu),
                Note = o.Note,
                Content = new List<SharedDataTypes.OrderContent>()
            };
        }

        public SharedDataTypes.OrderContent ConvertToSharedPackageOrderContentPackage(DataBases.Package p)
        {
            return new OrderContentPackage
            {
                OrderContentId = p.ID_Package,
                Package = ConvertToSharedPackage(p),
                Amount = p.OrderContent_has_Package.Select(q => q.Amount).First()
            };
        }

        public SharedDataTypes.OrderStatus ConvertToSharedOrderStatus(DataBases.OrderStatu os)
        {
            return new SharedDataTypes.OrderStatus()
            {
                OrderStatusId = os.ID_OrderStatus,
                Decription = os.StatusDescription
            };
        }

        public SharedDataTypes.Package ConvertToSharedPackage(DataBases.Package p)
        {
            return new SharedDataTypes.Package
            {
                PackageId = p.ID_Package,
                Name = p.Name,
                Description = p.Descripton,
                Image = p.Image,
                Customer = new SharedDataTypes.Customer(),
                Modified = p.ModifyDate,
                Ratings = new List<SharedDataTypes.Rating>(),
                Wrapping = ConvertToSharedWrapping(p.Wrapping1),
                Available = p.Availability,
                Chocolates = new List<SharedDataTypes.Chocolate>()
            };

        }

        public List<SharedDataTypes.Rating> ConvertToSharedRatings(ICollection<DataBases.Rating> r)
        {
            List<SharedDataTypes.Rating> tempRatings = new List<SharedDataTypes.Rating>();

            foreach (var item in r)
            {
                tempRatings.Add(new SharedDataTypes.Rating
                {
                    RatingId = item.ID_Rating,
                    Value = item.Value,
                    Date = item.Date,
                    Chocolate = ConvertToSharedChocolate(item.Chocolate),
                    Comment = item.Comment,
                    Customer = ConvertToSharedCustomer(item.Customer),
                    Package = ConvertToSharedPackage(item.Package),
                    Published = item.Published
                });
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

        public DataBases.Chocolate ConvertToDBChoco(SharedDataTypes.Chocolate c)
        {
            return new DataBases.Chocolate
            {
                ID_Chocolate = c.ChocolateId,
                Name = c.Name,
                Description = c.Description,
                Available = c.Available,
                Shape_ID = c.Shape.ShapeId,
                CustomStyle_ID = c.CustomStyle.CustomStyleId,
                Image = c.Image,
                Creator_Customer_ID = c.CreatedBy.CustomerId,
                ModifyDate = c.Modified.GetValueOrDefault(),
                WrappingID = c.Wrapping.WrappingId
            };
        }

        public DataBases.Package ConvertToDBPackage(SharedDataTypes.Package p)
        {
            return new DataBases.Package
            {
                ID_Package = p.PackageId,
                Name = p.Name,
                Descripton = p.Description,
                WrappingID = p.Wrapping.WrappingId,
                Availability = p.Available,
                Customer_ID = p.Customer.CustomerId,
                Image = p.Image,
                ModifyDate = p.Modified.GetValueOrDefault(),
            };
        }

        public DataBases.Ingredient ConvertToDBIngredient(SharedDataTypes.Ingredient i)
        {
            return new DataBases.Ingredient
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

    }
}
