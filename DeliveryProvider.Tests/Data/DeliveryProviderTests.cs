namespace DeliveryProvider.Tests.Data;
using DeliveryProvider.Data.Services;
using DeliveryProvider.Domain.Models;
using Xunit;

public class DeliveryServiceTests
{
    private readonly DeliveryService _deliveryService;
    public DeliveryServiceTests()
    {
        _deliveryService = new DeliveryService();
    }

    [Fact]
    public void ShouldSaveDeliveryInfo_WhenAddressAndPostCodeAreValid()
    {
        
        var deliveryInfo = new DeliveryInformation
        {
            Address = "Vallatorpsvägen 262",
            PostCode = "187 52",
            Email = "Karl.ybring@hotmail.com"
        };
        
        var result = _deliveryService.SaveDeliveryInfo(deliveryInfo);        
        
        Assert.True(result);
    }

    [Fact]
    public void ShouldReturnMessage_If_PackageExists()
    {
        Product product = new Product { Id = "123456"};

        _deliveryService.AddPackage(product);

     
        var result = _deliveryService.FindPackage(product);

        
        Assert.True(result.Success);
        Assert.Equal("Package has been delivered and is on its way", result.Message);
        Assert.Equal(200, result.StatusCode);
    }
}

