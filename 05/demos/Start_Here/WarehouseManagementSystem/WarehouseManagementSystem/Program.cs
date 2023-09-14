using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;


class Program
{
    private static void Main(string[] args)
    {
        var order = new Order
        {
            LineItems = new[]
            {
                new Item { Name = "PS1", Price = 50 },
                new Item { Name = "PS2", Price = 60 },
                new Item { Name = "PS4", Price = 70 },
                new Item { Name = "PS5", Price = 80 }
            }
        };

        var report = order.GenerateReport(recepient: "Tidiane Diallo");
        Console.WriteLine(report);  
    }
}