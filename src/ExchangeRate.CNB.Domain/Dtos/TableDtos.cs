using System.Xml.Serialization;

namespace ExchangeRate.CNB.Domain.Dtos;

[XmlRoot(ElementName = "tabulka")]
public class TableDtos
{
    [XmlElement(ElementName = "radek")]
    public List<RowDto> Rows { get; set; } = null!;

    [XmlAttribute(AttributeName = "typ")]
    public string Type { get; set; } = null!;
}