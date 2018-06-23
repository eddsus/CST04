using System;

namespace SharedDataTypes
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public DateTime? Modified { get; set; }

    }
}