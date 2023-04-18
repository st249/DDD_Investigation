using DDD_Investigation.Domain.OrderAggregate;

namespace DDD_Investigation.Domain.Shared
{
    public class OrderType : Enumeration
    {
        protected OrderType()
        {

        }
        protected OrderType(int id, string name) : base(id, name) { }


        public static OrderType Virtual = new OrderType(1, "Virtual".ToLowerInvariant());
        public static OrderType InPerson = new OrderType(2, "InPerson".ToLowerInvariant());
    }
}
