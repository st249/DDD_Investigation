namespace DDD_Investigation.Domain.OrderAggregate;

public class OrderItem
{
    public int Id { get; private set; }

    public string Name { get; private set; }    

    public Price Price { get; private set; }

    private OrderItem() { }
    public OrderItem(string name,Price price)
    {
        Name = name;
        Price = price;
    }
}
