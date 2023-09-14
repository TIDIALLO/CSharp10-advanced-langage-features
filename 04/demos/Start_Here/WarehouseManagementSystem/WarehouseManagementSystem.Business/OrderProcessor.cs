using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        // public delegate bool OrderInitialized(Order order);
        // public delegate void ProcessCompleted(Order order);

        public Func<Order, bool> OnOrderInitialized { get; set; }
        public event EventHandler<OrderCreatedEventArgs> OrderCreated;
        public virtual void OnOrderCreated(OrderCreatedEventArgs args)
        {
            OrderCreated?.Invoke(this, args);
        }
        private void Initialize(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            if (OnOrderInitialized?.Invoke(order) == false)
            {
                throw new Exception($"Couldn't initialize {order.OrderNumber}");
            }
        }

        public void Process(Order order,
            Action<Order> onCompleted = default)
        {
            Initialize(order);
            OnOrderCreated(new()
            {
                order = order,
                OldTotal = 100,
                NewTotal = 90,
            });
            onCompleted?.Invoke(order);
        }
    }
}