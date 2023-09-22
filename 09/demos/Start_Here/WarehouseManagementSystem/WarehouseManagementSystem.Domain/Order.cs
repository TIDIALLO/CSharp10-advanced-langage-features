using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Domain
{
    public record Order (
        decimal Total = 0,
        ShippingProvider ShippingProvider = default, 
        IEnumerable<Item> LineItems = default, 
        bool IsReadyForShipment = true
        )
    {
        public Guid OrderNumber { get; init; }
        /*public ShippingProvider ShippingProvider { get; init; }
        public int Total { get; set; }
        public bool IsReadyForShipment { get; set; } = true;
        public IEnumerable<Item> LineItems { get; set; }
*/
        /*       public Order()
               {
                   OrderNumber = Guid.NewGuid();
               }
       */
        public string GenerateReport(string email)
        {
            throw new NotImplementedException();
        }

   
        public static implicit operator decimal(Order order) => order.Total;
        public static explicit operator Order(List<Item> items)
        {
            return new(0m, new(), items.ToArray() );
        }
        
        public void Deconstruct(out decimal total,
            out bool ready)
        {
            total = Total;
            ready = IsReadyForShipment;
        }

        public void Deconstruct(out decimal total,
            out bool ready,
            out IEnumerable<Item> items)
        {
            total = Total;
            ready = IsReadyForShipment;
            items = LineItems;
        }
    
    }

    public record PriorityOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems,
        bool IsReadyForShipment = false
       ) : Order
         (Total, ShippingProvider ,LineItems, true){ };

    public record ShippedOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems
       ) : Order
    (Total, ShippingProvider, LineItems, false)
     {
        public DateTime ShippedDate { get; set; }
    }

    public record CancelledOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems
       ) : Order

    (Total, ShippingProvider, LineItems, false)
    {
        public DateTime CancelledDate { get; set; }
    }




   // public record ProcessedOrder : Order { }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}