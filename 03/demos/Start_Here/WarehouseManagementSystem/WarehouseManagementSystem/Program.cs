using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

var order = new Order
{
    LineItems = new[]
    {
        new Item{ Name = "PS1",Price = 50},
        new Item{ Name = "PS2",Price = 60},
        new Item{ Name = "PS3",Price = 70},
        new Item{ Name = "PS4",Price = 80}
    }
};

/*var processor = new OrderProcessor
{
    OnOrderInitialized = SendMessageToWarehouse
};
processor.Process(order, SendCofirmationnEmail);*/

OrderProcessor.OrderInitialized GetOnInitialized()
{
    return SendMessageToWarehouse;
}

//GetOnInitialized()(order);
GetOnInitialized()?.Invoke(order);


bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the ordre {order.OrderNumber}");
    return true;
}

void SendCofirmationnEmail(Order order)
{
    Console.WriteLine($"order confirmation email {order.OrderNumber}");
}