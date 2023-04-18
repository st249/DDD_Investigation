using DDD_Investigation.Domain.Shared;

namespace DDD_Investigation.Domain.OrderAggregate
{
    public class InPersonOrder : BaseOrder
    {

        public int InPersonCode { get; private set; }
        public override OrderType OrderType { get { return OrderType.InPerson; } protected set => value = OrderType.InPerson; }

        public InPersonOrder(string name, int customerId) : base(name, customerId)
        {

        }

        public void SetCode(int code)
        {
            InPersonCode = code;
        }
    }
}
