using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberToWordsConverter.Services
{
    public interface IFormatCurrency
    {
        string Format(string dollars, string cents);
    }
    public class FormatCurrency : IFormatCurrency
    {
        public string Format(string dollars, string cents)
        {
            if (string.IsNullOrWhiteSpace(cents))
            {
                return $"{dollars} Dollars".ToUpper();
            }
            return $"{dollars} Dollars and {cents} Cents".ToUpper();
        }
    }

}