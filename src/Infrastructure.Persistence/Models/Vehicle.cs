using System.ComponentModel.DataAnnotations;
using Domain.Vehicle.Enums;

namespace Infrastructure.Persistence.Models;

public class Vehicle
{
    [Key] [Required] public string Vin { get; set; } = null!;

    [Required] public Manufacturer Manufacturer { get; set; }

    [Required] [MaxLength(100)] public string Model { get; set; } = null!;
    
    [Required] public FuelType Fuel { get; set; }
    
    [Required] public VehicleType VehicleType { get; set; }
}