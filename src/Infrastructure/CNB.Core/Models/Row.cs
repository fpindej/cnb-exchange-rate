using System.Xml.Serialization;

namespace ExchangeRate.Infrastructure.CNB.Core.Models;

[XmlRoot(ElementName = "radek")]
public class Row
{
    [XmlAttribute(AttributeName = "kod")]
    public string Code { get; set; } = null!;

    [XmlAttribute(AttributeName = "mena")]
    public string CurrencyName { get; set; } = null!;

    [XmlAttribute(AttributeName = "mnozstvi")]
    public int Amount { get; set; }

    [XmlIgnore]
    private decimal Rate { get; set; }

    [XmlAttribute(AttributeName = "kurz")]
    public string RateFormatted
    {
        get => Rate.ToString(CNBConstants.RateFormat);
        set => Rate = decimal.Parse(value, CNBConstants.RateFormat);
    }

    [XmlAttribute(AttributeName = "zeme")]
    public string Country { get; set; } = null!;
}
