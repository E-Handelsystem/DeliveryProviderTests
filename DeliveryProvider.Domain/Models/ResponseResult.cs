namespace DeliveryProvider.Domain.Models;

public class ResponseResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
}
