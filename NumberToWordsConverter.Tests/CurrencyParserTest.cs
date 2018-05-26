using NumberToWordsConverter.Models;
using NumberToWordsConverter.Services;
using NUnit.Framework;

namespace NumberToWordsConverter.Tests
{
    [TestFixture]
    public class CurrencyParserTest
    {
        private ICurrencyParser _parserService;
        private ParsedCurrency _currency;

        [SetUp]
        public void SetUp()
        {
            _parserService = new CurrencyParser();
        }

        [Test]
        public void Parse_Currency_ShoulReturn_DollarsAndCents()
        {
            //Arrange
            var amount = new decimal(123.45);
            _currency = new ParsedCurrency
            {
                Dollars = 123,
                Cents = 45
            };
            //Action            
            var result = _parserService.Parse(amount);

            //Assert
            Assert.AreEqual(result.Dollars, _currency.Dollars);
            Assert.AreEqual(result.Cents, _currency.Cents);
        }

        [Test]
        public void Parse_WholeNumber_ShoulReturn_AllDollars()
        {
            //Arrange
            var amount = new decimal(5000);
            _currency = new ParsedCurrency
            {
                Dollars = 5000,
                Cents = 0
            };
            //Action            
            var result = _parserService.Parse(amount);

            //Assert
            Assert.AreEqual(result.Dollars, 5000);
        }

        [Test]
        public void Parse_WholeNumber_ShoulReturn_ZeroCents()
        {
            //Arrange
            var amount = new decimal(123);
            _currency = new ParsedCurrency
            {
                Dollars = 123,
                Cents = 0
            };
            //Action            
            var result = _parserService.Parse(amount);

            //Assert
            Assert.AreEqual(result.Cents, 0);
        }
    }
}
