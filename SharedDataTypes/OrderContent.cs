using System;

namespace SharedDataTypes
{
    public abstract class OrderContent
    {
        public Guid OrderContentId { get; set; }
        public int Amount { get; set; }

    }
}