using System;

namespace SharedDataTypes
{
    public class Adress
    {
        public Guid AdressId { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
    }
}