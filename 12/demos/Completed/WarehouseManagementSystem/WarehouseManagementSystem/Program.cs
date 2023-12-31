﻿using System.Text.Json;
using WarehouseManagementSystem;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

var processor = new OrderProcessor();


void ExecuteFileProcessor()
{
    var fileProcessor = new FileProcessor(processor);

    fileProcessor.Start();

    Console.WriteLine("Method Completed");
}

ExecuteFileProcessor();

GC.Collect();

Console.ReadLine();

#region Load the orders from orders.json
Order[] orders = JsonSerializer.Deserialize<Order[]>(File.ReadAllText("orders.json"))!;
#endregion

var subsetOfOrders = orders[..(orders.Length / 2)];

var payload = new byte[1024];
var validator = new PayloadValidator();

validator.Validate(payload);


int[] numbersForSlicing = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Index index = numbersForSlicing.Length / 2;


int[] slice = numbersForSlicing[..index];
// int[] slice = numbersForSlicing[^5..];

foreach (var element in slice)
{
    Console.WriteLine(element);
}


Console.ReadLine();

processor.OrderProcessCompleted += Processor_Completed;

void Processor_Completed(object? sender,
    OrderProcessCompletedEventArgs args)
{
    ArgumentNullException.ThrowIfNull(args.Order);

    ShippingProvider? provider
        = args.Order.ShippingProvider;

    // provider ??= new();
    if (ShippingProviderValidator.
        ValidateShippingProvider(provider))
    {
        var name = provider.Name;
    }










    Guid orderNumber = args.Order.OrderNumber;

    string orderNumberAsString = orderNumber.ToString();

}

processor.Process(orders: orders);




var items = new[]
{
    new Item { Name = "PS1", Price = 50 },
    new Item { Name = "PS2", Price = 60 },
    new Item { Name = "PS4", Price = 70 },
    new Item { Name = "PS5", Price = 80 }
};

Order order = new Order(101, null, items);














CancelledOrder cancelledOrder = new(101, new(), items);

Console.WriteLine(order.ToString());

Console.WriteLine();
Console.WriteLine();

Console.WriteLine(cancelledOrder.ToString());






Console.ReadLine();

var orderAsJson = JsonSerializer.Serialize(order,
    options: new() { WriteIndented = true });

Console.WriteLine(orderAsJson);

var orderFromJson
    = JsonSerializer.Deserialize<Order>(orderAsJson);


Console.ReadLine();



var customer = new Customer("Filip", "Ekberg")
{
    Address = new("Address", "1337")
};


var secondCustomer = new Customer("Filip", "Ekberg")
{
    Address = new("Address", "1337")
};


Console.WriteLine($"Are these instances equal? " +
    $"{customer == secondCustomer}");










Console.ReadLine();







Console.WriteLine(order.GenerateReport());

Console.ReadLine();







var isReadyForShipment = (Order order) =>
{
    return order.IsReadyForShipment;
};

// Deconstruct Other Objects 
var (orderTotal, isReady) = order;

var dictionary = new Dictionary<string, Order>();

foreach (var (orderId, theOrder) in dictionary)
{

}

// Using Tuples as Return Types or Parameters
foreach (var summary in processor.Process(orders))
{
    Console.WriteLine(summary.GenerateReport());
}

// Tuple elements ignored because of the names
(Guid id, int total) GetSummary()
{
    return (orderId: Guid.Empty, orderTotal: 10);
}

// var (id, items, total, _) = processor.Process(orders).First();

Action<(Guid id, int amountOfItems)> log = (tuple) =>
{

};

var first = processor.Process(orders).First();

var second = first with { amountOfItems = 0 };

Console.WriteLine($"Are these equal? {first == second}");

Console.ReadLine();

// Tuple Assignment and Deconstruction 
Guid orderNumber;
decimal sum;

(orderNumber, _, sum) =
    (order.OrderNumber,
    order.LineItems,
    order.LineItems.Sum(item => item.Price));

// Introducing Tuples 
var group = (order.OrderNumber, order.LineItems, order.LineItems.Sum(item => item.Price));
var groupAsAnonymousType = new
{
    order.OrderNumber,
    order.LineItems,
    Sum = order.LineItems.Sum(item => item.Price)
};

var json = JsonSerializer.Serialize(group,
options: new() { IncludeFields = true, WriteIndented = true });

Console.WriteLine(json);

Console.ReadLine();

// Modifying and Returning Anonymous Types 
var result = processor.Process(orders);

var type = result.GetType();
var properties = type.GetProperties();

foreach (var property in properties)
{
    Console.WriteLine($"Property: {property.Name}");
    Console.WriteLine($"Value: {property.GetValue(result)}");
}

Console.ReadLine();

// Introducing Anonymous Types
var subset = new
{
    order.OrderNumber,
    order.Total,
    AveragePrice = order.LineItems.Average(item => item.Price)
};

Console.WriteLine($"Average Price {subset.AveragePrice}");

Console.ReadLine();

var instance = new { Total = 100, AmountOfItems = 10 };

var secondInstance = new { Total = 100, AmountOfItems = 10 };

Console.WriteLine(instance.Equals(secondInstance));
Console.WriteLine(instance == secondInstance);

Console.ReadLine();

// Real-World Implementations of Extension Methods
var cheapestItems = order.LineItems.Where(item => item.Price > 60)
                                   .OrderBy(item => item.Price)
                                   .Take(5);
Console.ReadLine();

// Creating an Extension Method Library
var report = order.GenerateReport(recipient: "Filip Ekberg");
Console.WriteLine(report);


Console.ReadLine();

// Creating an Extension Method for IEnumerable<T> 
foreach (var item in order.LineItems.Find(item => item.Price > 60))
{
    Console.WriteLine(item.Price);
}

processor.OrderCreated += (sender, args) =>
{

};

processor.OrderCreated += Log;

processor.Process(order);


void Log(object sender, EventArgs args)
{
    Console.WriteLine("Log method call");
}

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");

    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Order Confirmation Email for {order.OrderNumber}");
}

Console.ReadLine();