using System.Globalization;

namespace ExchangeRate.CNB.Client;

internal static class CNBConstants
{
    public const string DateFormat = "dd.MM.yyyy";

    public static readonly NumberFormatInfo RateFormat = new() { NumberDecimalSeparator = "," };
}