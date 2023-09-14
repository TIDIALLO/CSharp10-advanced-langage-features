using WarehouseManagementSystem.Domain;
namespace WarehouseManagementSystem.Domain.Extensions;

public static class OrderExtensions
{
    public static string GenerateReport(this Order order, string recepient)
    {
        return $"ORDER REPORT ({order.OrderNumber})" +
                $"{Environment.NewLine}" +
                $"Items: {order.LineItems.Count()}" +
                $"{Environment.NewLine}" +
                $"Total: {order.Total}" +
                $"{Environment.NewLine}"+
                $"Send to: {recepient}";
    }
}
