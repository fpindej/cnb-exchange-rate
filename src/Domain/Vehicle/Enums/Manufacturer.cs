using System.Runtime.Serialization;

namespace Domain.Vehicle.Enums;

public enum Manufacturer
{
    [EnumMember(Value = "Toyota")] Toyota,
    [EnumMember(Value = "Ford")] Ford,
    [EnumMember(Value = "Honda")] Honda,
    [EnumMember(Value = "BMW")] Bmw
}