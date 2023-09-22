

namespace WarehouseManagementSystem.Domain;

public record class Customer(string FirstName, string LastName);

public record PriorityCustomer(string FirstName, string LastName): Customer(FirstName,LastName)
{

}
