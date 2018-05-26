using NumberToWordsConverter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberToWordsConverter.Services
{
    /// <summary>
    /// Converts Currency in number to Currency in words
    /// </summary>
    public class NumberToWordsService : INumberToWordsService
    {
        private readonly ICurrencyParser _currencyParser;
        private readonly ICurrencyOutputFormatter _currencyFormatter;
        private readonly ITranslateNumber _numberTranslator;
        private readonly IServiceConfigurations _serviceConfigurations;

        public NumberToWordsService(ICurrencyParser currencyParser, ICurrencyOutputFormatter currencyFormatter, ITranslateNumber numberTranslator, IServiceConfigurations serviceConfigurations)
        {
            _currencyParser = currencyParser;
            _currencyFormatter = currencyFormatter;
            _numberTranslator = numberTranslator;
            _serviceConfigurations = serviceConfigurations;
        }

        public ResponseCurrencyModel ConvertToWords(RequestCurrencyModel model)
        {
            //Validate
            ValidateCurrencyValue(model.Currency);

            //Parse Currency to Dollars and Cents
            var parsedCurrency = _currencyParser.Parse(model.Currency);

            //Convert Dollars to words
            var dollarsInWords = NumberToWords(parsedCurrency.Dollars);

            //Convert Cents to words
            var centsInWords = parsedCurrency.Cents > 0 ? NumberToWords(parsedCurrency.Cents) : string.Empty;

            //Foramt Dollars & Cents
            var currencyInWords = _currencyFormatter.Format(dollarsInWords, centsInWords);

            return new ResponseCurrencyModel
            {
                Name = model.Name,
                CurrencyInWords = currencyInWords
            };
        }

        private void ValidateCurrencyValue(decimal number)
        {
            if (number > _serviceConfigurations.MaxSupportedValue || number < 1)
            {
                throw new System.ArgumentOutOfRangeException();
            }
        }
        private string NumberToWords(int number)
        {
            StringBuilder sb = new StringBuilder();
            if (number == 0)
            {
                return GetTrasnalation(0);
            }


            sb.Append($"{GetEquilentWord(number, 1000000)}");
            number %= 1000000;

            sb.Append($"{GetEquilentWord(number, 1000)}");
            number %= 1000;

            sb.Append($"{GetEquilentWord(number, 100)}");
                number %= 100;
            if (number > 0)
            {
                sb.Append(GetEquilentHundredsWord(number));
            }
            return sb.ToString();
        }
        private string GetEquilentWord(int number, int unit)
        {
            StringBuilder sb = new StringBuilder();
            if ((number / unit) > 0)
            {
                sb.Append($"{NumberToWords(number / unit)} {_numberTranslator.Translate(unit)} ");
                if (number % unit != 0)
                {
                    sb.Append($"{_serviceConfigurations.CurrencyUnitsSepartor} ");
                }
            }
            return sb.ToString();
        }
        private string GetEquilentHundredsWord(int number)
        {
            StringBuilder sb = new StringBuilder();
            if (number < 20)
            {
                sb.Append(_numberTranslator.Translate(number));
            }
            else
            {
                var tens = number - (number % 10);
                sb.Append(_numberTranslator.Translate(tens));
                if ((number % 10) > 0)
                {
                    sb.Append($"{_serviceConfigurations.CurrencyUnitsConnector}{_numberTranslator.Translate(number % 10)}");
                }
            }
            return sb.ToString();
        }
        private string GetTrasnalation(int number)
        {
            return _numberTranslator.Translate(number);
        }
    }
}