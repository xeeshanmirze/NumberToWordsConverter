using NumberToWordsConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NumberToWordsConverter.Services
{
    public interface IConvertNumberToWordsService
    {
        ResponseCurrencyModel ConvertToWords(RequestCurrencyModel model);
    }
    public class ConvertNumberToWordsService : IConvertNumberToWordsService
    {
        private readonly ICurrencyParser _currencyParser;
        private readonly IFormatCurrency _currencyFormatter;
        private readonly ITranslateNumber _numberTranslator;

        public ConvertNumberToWordsService(ICurrencyParser currencyParser, IFormatCurrency currencyFormatter, ITranslateNumber numberTranslator)
        {
            _currencyParser = currencyParser;
            _currencyFormatter = currencyFormatter;
            _numberTranslator = numberTranslator;
        }
        public ResponseCurrencyModel ConvertToWords(RequestCurrencyModel model)
        {
            //Validate

            //Parse Dollars and Cents
            var parsedCurrency = _currencyParser.Parse(model.Currency);

            //Convert Dollars to words
            var dollarsInWords = NumberToWords(parsedCurrency.Dollars);

            //Convert Cents to words
            var centsInWords = NumberToWords(parsedCurrency.Cents);

            //Foramt Dollars & Cents
            var currencyInWords = _currencyFormatter.Format(dollarsInWords, centsInWords);

            //retrun;
            return new ResponseCurrencyModel
            {
                Name = model.Name,
                CurrencyInWords = currencyInWords
            };
        }

        //private StringBuilder _wordsBuilder;
        private string NumberToWords(int number)
        {
            StringBuilder words = new StringBuilder();
            if (number == 0)
                return "zero";

            //Process Million
            words.Append(Process(number, 1000000));
            number %= 1000000;
            //todo: verify logic
            //words = words.Replace(CurrencySepartor, " ");

            if (words.Length != 0)
                words.Append(CurrencySepartor);

            //Process Thousands
            words.Append(Process(number, 1000));
            number %= 1000;

            //if (words.Length != 0)
            //    words.Append(CurrencySepartor);

            words.Append(Process(number, 100));
            number %= 100;

            //words.Append(Process(number, 10));
            //number %= 10;

            if (number > 0)
            {
                if (words.Length != 0)
                    words.Append(TeensSepartor);

                //var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                //var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words.Append(_numberTranslator.Translate(number));//unitsMap[number];
                else
                {//21-99
                 //words.Append(_numberTranslator.Translate(number / 10));//tensMap[number / 10];

                    var tens = number - (number % 10);
                    words.Append(_numberTranslator.Translate(tens));//tensMap[number / 10];
                    if ((number % 10) > 0)
                        words.Append("-" + _numberTranslator.Translate(number % 10));//unitsMap[number % 10];
                }
            }

            return words.ToString();
        }
        private string CurrencySepartor = ", ";
        private string TeensSepartor = " & ";
        private string ProcessMillion(int number)
        {
            string value = string.Empty;
            int million = 1000000;
            if ((number / million) > 0)
            {
                value = $"{NumberToWords(number / million)} {_numberTranslator.Translate(million)}";
            }
            return value;
        }
        private string Process(int number, int unit)
        {
            string value = string.Empty;
            //int million = 1000000;
            if ((number / unit) > 0)
            {
                value = $"{NumberToWords(number / unit)} {_numberTranslator.Translate(unit)} ";
            }
            return value;
        }
        //1564;
        private string GetStringEquivalent(Int64 num)
        {
            var words = "";
            Int64 remainder = 0;

            if (num == 0)
                return words;

            int length = num.ToString().Length - 1;
            Int64 mask = 1;

            //10 power lenth
            for (int i = 0; i < length; i++)
                mask = mask * 10;

            Int64 digit = num / mask;
            remainder = num % mask;

            var digitText = GetText(digit);
            var htm = GetText(mask);
            words += $"{digitText} {htm}";

            Console.WriteLine(digit);

            GetStringEquivalent(remainder);
            return words;
        }

        private string GetText(Int64 number)
        {
            return _numberTranslator.Translate(number);
        }

    }
}