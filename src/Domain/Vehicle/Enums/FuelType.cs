using System.Runtime.Serialization;

namespace Domain.Vehicle.Enums;

public enum FuelType
{
    [EnumMember(Value = "Petrol")] Petrol,
    [EnumMember(Value = "Diesel")] Diesel,
    [EnumMember(Value = "Electric")] Electric,
    [EnumMember(Value = "Hybrid")] Hybrid
}