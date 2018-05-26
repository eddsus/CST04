using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.SharedTypeConverter
{
    public class SharedConverter
    {

        public SharedDataTypes.Order ConvertToSharedOrder(DataBases.Order p)
        {
            return new SharedDataTypes.Order()
            {
                OrderId = p.ID_Order,
                DateOfOrder = p.DateOfOrder,
                DateOfDelivery = p.DateOfDelivery,
                Customer = ConvertToSharedCustomer(p.Customer),
                Status = ConvertToSharedOrderStatus(p.OrderStatus),
                Note = p.Note,
                //Content = ConvertToSharedOrderContentList(p.OrderContent.ToList())
            };
        }

        //private static List<SharedDataTypes.OrderContent> ConvertToSharedOrderContentList(List<DataBases.OrderContent> oc)
        //{
        //    List<SharedDataTypes.OrderContent> tempList = new List<SharedDataTypes.OrderContent>();
        //    foreach (var item in oc)
        //    {
        //        if (item.OrderContent_has_Chocolate.Count > 0)
        //        {
        //            //I'm a choclolate
        //            tempList.Add(new SharedDataTypes.OrderContentChocolate() {
        //                OrderContentId = item.OrderContent_has_Chocolate.i
        //            });
        //        } else
        //        {
        //            //I'm a package
        //        }
        //        tempList.Add(new SharedDataTypes.OrderContent() {
                    
        //        });
        //    }
        //    return tempList;
        //}

        private static SharedDataTypes.OrderStatus ConvertToSharedOrderStatus(DataBases.OrderStatus os)
        {
            return new SharedDataTypes.OrderStatus()
            {
                Decription = os.StatusDescription
            };
        }

        public static SharedDataTypes.Customer ConvertToSharedCustomer(DataBases.Customer c)
        {
            return new SharedDataTypes.Customer()
            {
                CustomerId = c.ID_Customer,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = ConvertToSharedAddress(c.Address.First()),
                Mail = c.Mail,
                PhoneNumber = c.PhoneNumber,
            };
        }

        public static SharedDataTypes.Address ConvertToSharedAddress(DataBases.Address a)
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
    }
}
