namespace DeliveryProvider.Domain.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}