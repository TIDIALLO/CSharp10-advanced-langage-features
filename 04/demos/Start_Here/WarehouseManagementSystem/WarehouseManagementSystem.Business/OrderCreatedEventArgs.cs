

using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business;
public class OrderCreatedEventArgs
{
    public Order order { get; set; }   
    public decimal OldTotal { get; set; }   
    public decimal NewTotal { get; set; }
}
