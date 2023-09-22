

namespace WarehouseManagementSystem.Domain;

public record class Customer(string FirstName, string LastName)
{
    public string FullName => $"{FirstName} {LastName}";
    public Address Address { get; init; }
}


public record Address(string street, string postalCode);
public record PriorityCustomer(string FirstName, string LastName): Customer(FirstName,LastName)
{

}
