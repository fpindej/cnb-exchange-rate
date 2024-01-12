using Application.Interfaces.Repositories;
using Domain.Vehicle;
using Domain.Vehicle.Enums;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class VehicleRepository : IVehicleRepository
{
    private readonly CustomDbContext _dbContext;

    public VehicleRepository(CustomDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Vehicle> GetVehicleByIdAsync(string vin)
    {
        var vehicle = await _dbContext.Vehicles.FindAsync(vin) ?? throw new KeyNotFoundException();
        return new Vehicle
        {
            Vin = new VehicleIdentificationNumber(vehicle.Vin),
            Manufacturer = vehicle.Manufacturer,
            Model = vehicle.Model,
            VehicleType = vehicle.VehicleType
        };
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
    {
        var vehicles = await _dbContext.Vehicles.ToListAsync();
        return vehicles.Select(vehicle => new Vehicle
        {
            Vin = new VehicleIdentificationNumber(vehicle.Vin),
            Manufacturer = vehicle.Manufacturer,
            Model = vehicle.Model,
            Fuel = vehicle.Fuel,
            VehicleType = vehicle.VehicleType
        });
    }

    public async Task AddVehicleAsync(Vehicle vehicle)
    {
        var vehicleModel = new Persistence.Models.Vehicle
        {
            Vin = vehicle.Vin.ToString(),
            Manufacturer = vehicle.Manufacturer,
            Model = vehicle.Model,
            Fuel = vehicle.Fuel,
            VehicleType = vehicle.VehicleType
        };
        await _dbContext.Vehicles.AddAsync(vehicleModel);
        await _dbContext.SaveChangesAsync();
    }
}