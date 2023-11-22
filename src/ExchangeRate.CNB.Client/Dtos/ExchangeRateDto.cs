using System.Globalization;
using System.Xml.Serialization;

namespace ExchangeRate.CNB.Client.Dtos;

[XmlRoot(ElementName = "kurzy")]
public class ExchangeRateDto
{
    [XmlElement(ElementName = "tabulka")]
    public TableDto Tables { get; set; } = null!;

    [XmlAttribute(AttributeName = "banka")]
    public string Bank { get; set; } = null!;

    [XmlIgnore]
    public DateTime Date { get; set; }

    [XmlAttribute("datum")]
    public string DateFormatted
    {
        get => Date.ToString(CNBConstants.DateFormat, CultureInfo.InvariantCulture);
        set => Date = DateTime.ParseExact(value, CNBConstants.DateFormat, CultureInfo.InvariantCulture);
    }

    [XmlAttribute(AttributeName = "poradi")]
    public int OrderNo { get; set; }
}