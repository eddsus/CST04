using System;

namespace SharedDataTypes
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string UnitType { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }




    }
}