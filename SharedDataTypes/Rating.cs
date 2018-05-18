using System;

namespace SharedDataTypes
{
    public class Rating
    {
        public Guid RatingId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool Published { get; set; }
        public Customer Customer { get; set; }
        public Package Package { get; set; }
        public Chocolate Chocolate { get; set; }
    }
}