using System.Globalization;

namespace ExchangeRate.CNB.Domain;

internal static class CNBConstants
{
    public const string DateFormat = "dd.MM.yyyy";

    public static readonly NumberFormatInfo RateFormat = new() { NumberDecimalSeparator = "," };
}