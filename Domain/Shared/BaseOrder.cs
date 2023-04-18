using DDD_Investigation.Domain.OrderAggregate;

namespace DDD_Investigation.Domain.Shared
{
    public abstract class BaseOrder
    {
        public abstract OrderType OrderType { get; protected set; }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public OrderStatus Status { get; private set; }

        private List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public int CustomerId { get; private set; }

        private BaseOrder() { }
        protected BaseOrder(string name, int customerId)
        {
            Name = name;
            Status = OrderStatus.Created;
            CustomerId = customerId;
        }

        public void AddOrderItem(string name, Price price)
        {
            var oi = new OrderItem(name, price);
            _orderItems.Add(oi);
        }

        public void ClearItems()
        {
            _orderItems.Clear();
        }

    }
}
