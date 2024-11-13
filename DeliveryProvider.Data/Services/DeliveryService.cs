using DeliveryProvider.Domain.Models;

namespace DeliveryProvider.Data.Services;

public class DeliveryService
{
    private readonly List<Product> _packages = new List<Product>();
    public bool SaveDeliveryInfo(DeliveryInformation deliveryInfo)
    {
        try
        {
            if (string.IsNullOrEmpty(deliveryInfo.Address))
            {
                Console.WriteLine("Du måste ange adress och postnummer och email");
                return false;
                
            }
            if (string.IsNullOrEmpty(deliveryInfo.Email))
            {
                Console.WriteLine("Du måste ange en email");
                return false;
            }
            if (string.IsNullOrEmpty(deliveryInfo.PostCode))
            {
                Console.WriteLine("Du måste ange ett Postnummer");
                return false;
            }
            return true;
        }
        catch
        {
            return false;
        }
    } 
    public void AddPackage(Product product)
    {
        _packages.Add(product);
    }
    public ResponseResult FindPackage(Product product)
    {
        var PackageFound  = _packages.Any(p => p.Id == product.Id);

        try
        {
            if (PackageFound)
            {
                return new ResponseResult()
                {
                    Success = true,
                    Message = "Package has been delivered and is on its way",
                    StatusCode = 200
                };
            }
            return new ResponseResult()
            {
                Success = false,
                Message = "Package not found",
                StatusCode = 404
            };
        }
        catch
        {
            return new ResponseResult()
            {
                Success = true,
                Message = "Error",
                StatusCode = 500,
            };
        }
    }
}

