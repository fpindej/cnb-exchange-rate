using Application.Interfaces.Repositories;
using Domain.Vehicle;
using Domain.Vehicle.Enums;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleController(ILogger<VehicleController> logger, IVehicleRepository vehicleRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleReadDto>>> GetAllVehiclesAsync()
    {
        _logger.LogInformation("GetAllVehiclesAsync => Getting all vehicles");
        var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
        var result = vehicles.Select(v => new VehicleReadDto(
            v.Vin.ToString(),
            v.Manufacturer.ToString(),
            v.Model,
            v.Fuel.ToString(),
            v.VehicleType.ToString()));

        return Ok(result);
    }

    [HttpGet("{vin}")]
    public async Task<IActionResult> GetVehicleByIdAsync(string vin)
    {
        _logger.LogInformation($"GetVehicleByIdAsync => Getting vehicle with vin: {vin}");
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vin);
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleCreateDto vehicle)
    {
        _logger.LogInformation("AddVehicleAsync => Adding vehicle with vin: {vehicle.VIN}", vehicle.Vin);

        var v = new Vehicle
        {
            Vin = new VehicleIdentificationNumber(vehicle.Vin),
            Manufacturer = Enum.Parse<Manufacturer>(vehicle.Manufacturer),
            Model = vehicle.Model,
            Fuel = Enum.Parse<FuelType>(vehicle.FuelType),
            VehicleType = Enum.Parse<VehicleType>(vehicle.VehicleType)
        };
        await _vehicleRepository.AddVehicleAsync(v);
        return Ok();
    }

    public class VehicleReadDto(
        string Vin,
        string Manufacturer,
        string Model,
        string FuelType,
        string VehicleType);
}