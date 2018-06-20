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
        //use SharedTypeConverter for converting from DataBaseClasses to SharedDataTypes
        SharedConverter converter = new SharedConverter();

        ChocolateCustomizerEntities mainDb = new ChocolateCustomizerEntities();

        #region GiveMeAll Queries

        public List<SharedDataTypes.Rating> QueryRatings()
        {
            return converter.ConvertToSharedRatings(mainDb.Rating.Select(p => p).ToList());
        }

        public List<SharedDataTypes.Order> QueryOrders()
        {
            List<SharedDataTypes.Order> tempSharedOrders = new List<SharedDataTypes.Order>();
            foreach (var item in mainDb.Order.Select(p => p).ToList())
            {
                tempSharedOrders.Add(converter.ConvertToSharedOrder(item));
            }
            return tempSharedOrders;
        }

        public List<SharedDataTypes.OrderContentChocolate> QueryOrdersContentChocolate(string orderId)
        {
            var temp = mainDb.OrderContent.Where(o => o.Order_ID.Equals(orderId)).Select(oc => oc).ToList();
            return converter.ConvertOrdersContentChocolate(temp);
        }

        public List<SharedDataTypes.OrderContentPackage> QueryOrdersContentPackage(string orderId)
        {
            var temp = mainDb.OrderContent.Where(o => o.Order_ID.Equals(orderId)).Select(oc => oc).ToList();
            return converter.ConvertOrdersContentPackage(temp);
        }

        public List<SharedDataTypes.Chocolate> QueryChocolatesWithIngredients()
        {
            List<SharedDataTypes.Chocolate> sharedChocolates = new List<SharedDataTypes.Chocolate>();

            foreach (var choco in mainDb.Chocolate.Select(p => p).ToList())
            {
                sharedChocolates.Add(converter.ConvertToSharedChocolate(choco));
            }


            foreach (var tempChoco in sharedChocolates)
            {
                tempChoco.Ingredients = QueryIngredientsByChocolateId(tempChoco.ChocolateId);
            }
            return sharedChocolates;
        }

        public List<SharedDataTypes.Chocolate> QueryChocolatesWithIngredientsByPackageId(Guid packageId)
        {
            List<SharedDataTypes.Chocolate> sharedChocolates = new List<SharedDataTypes.Chocolate>();

            foreach (var choco in mainDb.Chocolate.Where(p => p.Package_has_Chocolate.Count(q => q.Package_ID.Equals(packageId)) > 0).Select(p => p).ToList())
            {
                sharedChocolates.Add(converter.ConvertToSharedChocolate(choco));
            }


            foreach (var tempChoco in sharedChocolates)
            {
                tempChoco.Ingredients = QueryIngredientsByChocolateId(tempChoco.ChocolateId);
            }
            return sharedChocolates;
        }

        public List<SharedDataTypes.Package> QueryPackagesWithChocolatesAndIngredients()
        {
            List<SharedDataTypes.Package> tempSharedPackages = new List<SharedDataTypes.Package>();

            foreach (var item in mainDb.Package.Select(p => p).ToList())
            {
                tempSharedPackages.Add(converter.ConvertToSharedPackage(item));
            }

            foreach (var item in tempSharedPackages)
            {
                //to be checked
                item.Customer = QueryCustomerByPackageId(item.PackageId);
                item.Chocolates = QueryChocolatesWithIngredientsByPackageId(item.PackageId);
            }
            return tempSharedPackages;
        }

        public SharedDataTypes.Customer QueryCustomerByPackageId(Guid packageId)
        {
            return converter.ConvertToSharedCustomer(mainDb.Package.Where(p => p.ID_Package == packageId).Select(p => p.Customer).First());
        }

        public SharedDataTypes.Customer QueryCustomerByCustomerId(Guid customerId)
        {
            return converter.ConvertToSharedCustomer(mainDb.Customer.Where(p => p.ID_Customer.Equals(customerId)).Select(p => p).First());
        }

        public List<SharedDataTypes.Customer> QueryCustomers()
        {
            List<SharedDataTypes.Customer> tempCustomers = new List<SharedDataTypes.Customer>();
            foreach (var item in mainDb.Customer.Select(p => p).ToList())
            {
                tempCustomers.Add(converter.ConvertToSharedCustomer(item));
            }
            return tempCustomers;
        }

        public List<SharedDataTypes.Shape> QueryShapes()
        {
            List<SharedDataTypes.Shape> tempShapes = new List<SharedDataTypes.Shape>();

            foreach (var item in mainDb.Shape.Select(p => p).ToList())
            {
                tempShapes.Add(converter.ConvertToSharedShape(item));
            }
            return tempShapes;
        }

        public List<SharedDataTypes.Wrapping> QueryWrappings()
        {
            List<SharedDataTypes.Wrapping> sharedWrappings = new List<SharedDataTypes.Wrapping>();

            foreach (var item in mainDb.Wrapping.Select(p => p).ToList())
            {
                sharedWrappings.Add(converter.ConvertToSharedWrapping(item));
            }
            return sharedWrappings;
        }

        public List<SharedDataTypes.Ingredient> QueryIngredients()
        {
            List<SharedDataTypes.Ingredient> tempIngredients = new List<SharedDataTypes.Ingredient>();

            foreach (DataBases.Ingredients item in mainDb.Ingredients.Select(i => i).ToList())
            {
                tempIngredients.Add(converter.ConvertToSharedIngredient(item));
            }
            return tempIngredients;
        }

        public List<SharedDataTypes.Ingredient> QueryIngredientsByChocolateId(Guid chocoId)
        {
            List<SharedDataTypes.Ingredient> tempIngredients = new List<SharedDataTypes.Ingredient>();

            foreach (var item in mainDb.Ingredients.Where(p => p.Chocolate.Count(x => x.ID_Chocolate.Equals(chocoId)) > 0).ToList())
            {
                tempIngredients.Add(converter.ConvertToSharedIngredient(item));
            }
            return tempIngredients;
        }

        public List<SharedDataTypes.OrderStatus> QueryOrderStates()
        {
            List<SharedDataTypes.OrderStatus> tempSharedOrderStates = new List<SharedDataTypes.OrderStatus>();
            foreach (DataBases.OrderStatus item in mainDb.OrderStatus.Select(p => p).ToList())
            {
                tempSharedOrderStates.Add(converter.ConvertToSharedOrderStatus(item));
            }
            return tempSharedOrderStates;
        }

        public List<SharedDataTypes.Rating> QueryRatingsByPackageId(Guid PackageId)
        {
            return converter.ConvertToSharedRatings(mainDb.Rating.Where(p => p.Package_ID.Equals(PackageId)).Select(p => p).ToList());
        }

        public List<SharedDataTypes.Rating> QueryRatingsByChocoId(Guid ChocoId)
        {
            return converter.ConvertToSharedRatings(mainDb.Rating.Where(p => p.Chocolate_ID.Equals(ChocoId)).Select(p => p).ToList());
        }


        #endregion

        #region DELETE METHODS

        //delete order content by order no.

        #endregion

        #region INSERT METHODS
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

        public bool InsertIngredient(SharedDataTypes.Ingredient newIngredient)
        {
            mainDb.Ingredients.Add(converter.ConvertToDBIngredient(newIngredient));
            return mainDb.SaveChanges() > 0;
        }
        #endregion

        #region UPDATE METHODS
        public bool UpdateIngredient(SharedDataTypes.Ingredient i)
        {
            var temp = mainDb.Ingredients.Where(p => p.ID_Ingredients == i.IngredientId).Select(j => j).First();

            temp.Name = i.Name;
            temp.Description = i.Description;
            temp.Price = i.Price;
            temp.Availability = i.Available;
            temp.Type = i.Type;
            temp.UnitType = i.UnitType;
            temp.ModifyDate = DateTime.Now;
            return mainDb.SaveChanges() == 1;
        }

        public bool UpdateChocolate(SharedDataTypes.Chocolate c)
        {
            var temp = mainDb.Chocolate.Where(p => p.ID_Chocolate.Equals(c.ChocolateId)).Select(p => p).First();

            temp.Name = c.Name;
            temp.Description = c.Description;
            temp.Available = c.Available;
            temp.Image = c.Image;
            temp.WrappingID = c.Wrapping.WrappingId;
            temp.Shape_ID = c.Shape.ShapeId;
            temp.ModifyDate = DateTime.Now;

            return mainDb.SaveChanges() == 1;
        }

        public bool ChangeStateOfAnOrder(Guid orderId, SharedDataTypes.OrderStatus status)
        {
            var temp = mainDb.Order.Where(p => p.ID_Order.Equals(orderId)).Select(p => p).First();

            temp.Status_ID = status.OrderStatusId;

            return mainDb.SaveChanges() == 1;
        }

        public bool UpdatePackage(SharedDataTypes.Package p)
        {
            var temp = mainDb.Package.Where(q => q.ID_Package.Equals(q.ID_Package)).Select(q => q).First();

            temp.Name = p.Name;
            temp.Descripton = p.Description;
            temp.WrappingID = p.Wrapping.WrappingId;
            temp.Availability = p.Available;
            temp.Customer_ID = p.Customer.CustomerId;
            temp.Wrapping = p.Wrapping.Name;
            temp.Image = p.Image;
            temp.ModifyDate = DateTime.Now;

            return mainDb.SaveChanges() == 1;
        }
        #endregion
    }
}