using Domain.Vehicle.Enums;

namespace Domain.Vehicle;

public sealed class Vehicle
{
    public VehicleIdentificationNumber Vin { get; init; }

    public Manufacturer Manufacturer { get; init; }

    public string Model { get; init; } = null!;

    public FuelType Fuel { get; init; }

    public VehicleType VehicleType { get; init; }
}