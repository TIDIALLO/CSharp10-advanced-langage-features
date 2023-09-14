using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

Order order = new Order
{
    LineItems = new[]
    {
        new Item { Name = "PS1", Price = 50 },
        new Item { Name = "PS2", Price = 60 },
        new Item { Name = "PS4", Price = 70 },
        new Item { Name = "PS5", Price = 80 }
    }
};
/*var instance = new { Total = 100, AmountOfItems = 10 };
var instance2 = new { Total = 100, AmountOfItems =10};

Console.WriteLine(instance.Equals(instance2));  // check the referene equality
Console.WriteLine(instance  == instance2);// check properties
Console.ReadLine();*/

var subset = new
{
    order.OrderNumber,
    order.Total,
    AveragePrice = order.LineItems.Average(item => item.Price)
};
Console.WriteLine(subset);

var instance = new
{
    Read = new Func<String>(Console.ReadLine)
};

instance.Read();