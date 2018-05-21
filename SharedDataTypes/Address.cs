using System;

namespace SharedDataTypes
{
    public class Address
    {
        public Guid AdressId { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
    }
}