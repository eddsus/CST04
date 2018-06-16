using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedDataTypes
{
    public class Chocolate
    {
        public Guid ChocolateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public Shape Shape { get; set; }
        public CustomStyle CustomStyle { get; set; }
        public Uri Image { get; set; }
        public Wrapping Wrapping { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Rating> Ratings { get; set; }
        public int AverageRating
        {
            get
            {
                if (Ratings != null)
                    return Ratings.Select(r => r.Value).Sum() / Ratings.Count;
                else return -1;
            }
        }
        public DateTime? Modified { get; set; }
        public Customer CreatedBy { get; set; }

    }
}