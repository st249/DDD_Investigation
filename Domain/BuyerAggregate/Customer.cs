using DDD_Investigation.Domain.OrderAggregate;

namespace DDD_Investigation.Domain.BuyerAggregate;

public class Customer
{
    public int Id { get;private set; }
    public string Name { get;private set; }

    private List<int> _orderIds = new List<int>();  
 
    public Customer(string name)
    {
        Name = name;
    }

    private Customer() { }

    internal void SetName(string name)
    {
        Name= name;
    }
}


public record CustomerId(int Value) { }
