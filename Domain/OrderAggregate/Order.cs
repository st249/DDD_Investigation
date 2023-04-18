using DDD_Investigation.Domain.BuyerAggregate;
using DDD_Investigation.Domain.Shared;

namespace DDD_Investigation.Domain.OrderAggregate;

public class VirtualOrder : BaseOrder
{
    public override OrderType OrderType { get { return OrderType.Virtual; } protected set => value = OrderType.Virtual; }
    

    public decimal PostCost { get;private set; }

    public VirtualOrder(string name, int customerId) : base(name, customerId)
    {

    }


    public void SetPostCost(decimal postCost)
    {
        PostCost = postCost;
    }

}
