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

        public List<SharedDataTypes.Order> QueryOrders()
        {
            List<SharedDataTypes.Order> tempSharedOrders = new List<SharedDataTypes.Order>();

            foreach (var item in mainDb.Orders.Select(p => p).ToList())
            {
                tempSharedOrders.Add(converter.ConvertToSharedOrder(item));

            }

            foreach (var tempOrder in tempSharedOrders)
            {
                //int cnt = 0;
                //SharedOrderContent is abstract
                foreach (var tempOrderContent in mainDb.OrderContents.Where(p => p.Order_ID.Equals(tempOrder.OrderId)).Select(p => p).ToList())
                {
                    //cnt++;
                    if (mainDb.Chocolates.Where(p => p.OrderContent_has_Chocolate.Count(x => x.OrderContent_ID == tempOrderContent.ID_OrderContent) > 0) == null)
                    {
                        //get DBChocolate and ConvertToSharedChocolateOrderContentChocolate
                        tempOrder.Content.Add(converter.ConvertToSharedChocolateOrderContentChocolate(
                            mainDb.Chocolates.Where(p => p.OrderContent_has_Chocolate.Count(x => x.OrderContent_ID == tempOrderContent.ID_OrderContent) > 0).
                            Select(p => p).First()));
                    }
                    else
                    {
                        //get DBPackage and ConvertToSharedPackageOrderContentPackage
                        tempOrder.Content.Add(converter.ConvertToSharedPackageOrderContentPackage(
                            mainDb.Packages.Where(p => p.OrderContent_has_Package.Count(x => x.OrderContent_ID == tempOrderContent.ID_OrderContent) > 0).
                            Select(p => p).First()));
                    }
                }

                //foreach (var orderContent in tempOrder.Content)
                //{
                //    if (orderContent is SharedDataTypes.OrderContentChocolate)
                //    {
                //        orderContent.GetType()
                //    }
                //}
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


        public List<SharedDataTypes.Chocolate> QueryChocolatesWithIngredientsByPackageId(Guid packageId)
        {
            List<SharedDataTypes.Chocolate> sharedChocolates = new List<SharedDataTypes.Chocolate>();

            foreach (var choco in mainDb.Chocolates.Where(p => p.Package_has_Chocolate.Count(q => q.Package_ID.Equals(packageId)) > 0).Select(p => p).ToList())
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

            foreach (var item in mainDb.Packages.Select(p => p).ToList())
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
            //to be checked
            return converter.ConvertToSharedCustomer(mainDb.Customers.Where(p => p.Ratings.Count(x => x.Package_ID.Equals(packageId)) > 0).First());
        }

        public SharedDataTypes.Customer QueryCustomerByCustomerId(Guid customerId)
        {
            return converter.ConvertToSharedCustomer(mainDb.Customers.Where(p => p.ID_Customer.Equals(customerId)).Select(p => p).First());
        }

        public List<SharedDataTypes.Customer> QueryCustomers()
        {
            List<SharedDataTypes.Customer> tempCustomers = new List<SharedDataTypes.Customer>();
            foreach (var item in mainDb.Customers.Select(p => p).ToList())
            {
                tempCustomers.Add(converter.ConvertToSharedCustomer(item));
            }
            return tempCustomers;
        }

        public List<SharedDataTypes.Shape> QueryShapes()
        {
            List<SharedDataTypes.Shape> tempShapes = new List<SharedDataTypes.Shape>();

            foreach (var item in mainDb.Shapes.Select(p => p).ToList())
            {
                tempShapes.Add(converter.ConvertToSharedShape(item));
            }
            return tempShapes;
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
            List<SharedDataTypes.Ingredient> tempIngredients = new List<SharedDataTypes.Ingredient>();

            foreach (DataBases.Ingredient item in mainDb.Ingredients.Select(i => i).ToList())
            {
                tempIngredients.Add(converter.ConvertToSharedIngredient(item));
            }
            return tempIngredients;
        }

        public List<SharedDataTypes.Ingredient> QueryIngredientsByChocolateId(Guid chocoId)
        {
            List<SharedDataTypes.Ingredient> tempIngredients = new List<SharedDataTypes.Ingredient>();

            foreach (var item in mainDb.Ingredients.Where(p => p.Chocolates.Count(x => x.ID_Chocolate.Equals(chocoId)) > 0).ToList())
            {
                tempIngredients.Add(converter.ConvertToSharedIngredient(item));
            }
            return tempIngredients;
        }

        public List<SharedDataTypes.OrderStatus> QueryOrderStates()
        {
            List<SharedDataTypes.OrderStatus> tempSharedOrderStates = new List<OrderStatus>();
            foreach (DataBases.OrderStatu item in mainDb.OrderStatus.Select(p => p).ToList())
            {
                tempSharedOrderStates.Add(converter.ConvertToSharedOrderStatus(item));
            }
            return tempSharedOrderStates;
        }


        public List<SharedDataTypes.Rating> QueryRatingsByPackageId(Guid PackageId)
        {
            return converter.ConvertToSharedRatings(mainDb.Ratings.Where(p => p.Package_ID.Equals(PackageId)).Select(p => p).ToList());
        }

        public List<SharedDataTypes.Rating> QueryRatingsByChocoId(Guid ChocoId)
        {
            return converter.ConvertToSharedRatings(mainDb.Ratings.Where(p => p.Chocolate_ID.Equals(ChocoId)).Select(p => p).ToList());
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
            mainDb.Ingredients.Add(converter.ConvertToDBIngredient(newIngredient));
            return mainDb.SaveChanges() > 0;
        }
        #endregion

        #region UPDATE METHODS
        public bool UpdateIngredient(SharedDataTypes.Ingredient item )
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