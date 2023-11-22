using System.ComponentModel.DataAnnotations;

namespace ExchangeRate.CNB.Client;

public class CNBConfiguration
{
    public const string SectionName = "CNB";

    [Required]
    public Uri BaseUrl { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public string DefaultCurrency { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public string RequestUrl { get; set; }
    
    [Required]
    public int? RetryCount { get; set; }
}