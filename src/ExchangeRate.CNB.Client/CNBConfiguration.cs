using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace ExchangeRate.CNB.Client;

public class CNBConfiguration
{
    public const string SectionName = "CNB";

    [Required]
    public Uri BaseUrl { get; [UsedImplicitly] set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public string DefaultCurrency { get; [UsedImplicitly] set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public string RequestUrl { get; [UsedImplicitly] set; } = null!;

    [Required] 
    public int RetryCount { get; [UsedImplicitly] set; } = 3;
}