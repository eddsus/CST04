using System;

namespace SharedDataTypes
{
    public class CustomStyle
    {
        public Guid CustomStyleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Modified { get; set; }

    }
}