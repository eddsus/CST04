using Newtonsoft.Json;
using System;

namespace SharedDataTypes
{
    public class Ingredient
    {
        [JsonProperty("IngredientId")]
        public Guid IngredientId { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Price")]
        public double Price { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("UnitType")]
        public string UnitType { get; set; }
        [JsonProperty("Available")]
        public bool Available { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }




    }
}