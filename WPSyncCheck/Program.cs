using DataManagement;
using SharedDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPDataRepo;

namespace WPSyncCheck
{
    class Program
    {
        static DataHandlerMain maindh = new DataHandlerMain();
        static WPDataHandler wpdh = new WPDataHandler();

        static void Main(string[] args)
        {
            
            while (true)
            {
                UpdateOrders();
                UpdateComments();
                Thread.Sleep(10000);
            }
        }

        private static void UpdateComments()
        {

            throw new NotImplementedException();
        }

        private static void UpdateOrders()
        {
            foreach (var serverorder in maindh.QueryOrders())
            {
                foreach (var wporder in wpdh.CheckForNewOrders(serverorder.Modified.GetValueOrDefault()))
                {
                    if (serverorder.Modified < wporder.Modified)
                    {
                        maindh.InsertOrder(new Order(){
                            OrderId=wporder.ID,
                            Customer= new Customer()
                            {
                                CustomerId=Guid.NewGuid(),
                                FirstName=wporder.Firstname,
                                LastName=wporder.Lastname,
                                PhoneNumber=wporder.Telephone,
                                Modified=wporder.Modified,
                                Mail=wporder.Mail
                            },
                            DateOfDelivery=DateTime.Now.AddDays(4),
                            Modified=wporder.Modified,
                            DateOfOrder=wporder.OrderDate,
                            Note=wporder.CustomerNotes,
                            Status=ConvertToSyncStatus(wporder.OrderStatus)
                        });
                    }
                }
            }

        }

        private static OrderStatus ConvertToSyncStatus(string orderStatus)
        {
            switch (orderStatus)
            {
                case "wc-cancelled":
                    return new OrderStatus()
                    {
                        OrderStatusId = new Guid("4677B96E-D1A0-47BC-95DB-52730C3D9985"),
                        Decription = "Canceled",
                        Modified = DateTime.Now
                    };
                case "wc-on-hold":
                    return new OrderStatus()
                    {
                        OrderStatusId = new Guid("E9EA67D5-BEE2-4372-9ABB-408A2AFE3640"),
                        Decription = "Paused",
                        Modified = DateTime.Now
                    };
                default:
                    return new OrderStatus()
                    {
                        OrderStatusId = new Guid("0C16612C-9AD3-4FFE-BB58-3EA434E0F91F"),
                        Decription = "New",
                        Modified = DateTime.Now
                    };
            }
            
        }
    }
}
