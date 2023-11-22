using System.Net.Mime;
using ExchangeRate.CNB.Client;
using ExchangeRate.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : ControllerBase
{
    private readonly ILogger<ExchangeRateController> _logger;

    private readonly IExchangeRateProvider _provider;

    public ExchangeRateController(ILogger<ExchangeRateController> logger, IExchangeRateProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult> GetAll()
    {
        var exchangeRates = await _provider.GetExchangeRatesAsync();

        var result = exchangeRates.Select(r => new ExchangeRateDto
        {
            SourceCurrengy = r.SourceCurrency,
            TargetCurrency = r.TargetCurrency,
            Amount = r.Amount
        });
        
        return Ok(result);
    }
}