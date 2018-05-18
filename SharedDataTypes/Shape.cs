using System;

namespace SharedDataTypes
{
    public class Shape
    {
        public Guid ShapeId { get; set; }
        public string Name { get; set; }
        public Uri Image { get; set; }
    }
}