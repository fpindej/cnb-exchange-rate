using System.Runtime.Serialization;

namespace Domain.Vehicle.Enums;

public enum VehicleType
{
    [EnumMember(Value = "Car")] Car,
    [EnumMember(Value = "Motorcycle")] Motorcycle
}