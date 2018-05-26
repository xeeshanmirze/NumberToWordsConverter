using NumberToWordsConverter.Models;
using System;
using System.Globalization;

namespace NumberToWordsConverter.Services
{
    /// <summary>
    /// Parse dollars and cents from amount
    /// </summary>
    public class CurrencyParser : ICurrencyParser
    {
        public ParsedCurrency Parse(decimal amount)
        {
            var parsed = amount.ToString(CultureInfo.InvariantCulture).Split('.');
            return new ParsedCurrency
            {
                Dollars = Convert.ToInt32(parsed[0]),
                Cents = parsed.Length == 2 ? Convert.ToInt32(parsed[1]) : 0
            };
        }
    }
}