using System.Xml.Serialization;

namespace ExchangeRate.Infrastructure.CNB.Core.Models;

[XmlRoot(ElementName = "tabulka")]
public sealed class Table
{
    [XmlElement(ElementName = "radek")]
    public List<Row> Rows { get; set; } = null!;

    [XmlAttribute(AttributeName = "typ")]
    public string Type { get; set; } = null!;
}
