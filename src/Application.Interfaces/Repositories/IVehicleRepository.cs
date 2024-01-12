using Domain.Vehicle;

namespace Application.Interfaces.Repositories;

public interface IVehicleRepository
{
    Task<Vehicle> GetVehicleByIdAsync(string vin);
    
    Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
    
    Task AddVehicleAsync(Vehicle vehicle);
}