namespace WebApi.Dtos;

public sealed class VehicleCreateDto
{
    public string Vin { get; init; } = null!;
    
    public string Manufacturer { get; init; } = null!;
    
    public string Model { get; init; } = null!;
    
    public string FuelType { get; init; } = null!;
    
    public string VehicleType { get; init; } = null!;
}