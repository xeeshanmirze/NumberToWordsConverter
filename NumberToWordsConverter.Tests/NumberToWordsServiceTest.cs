using NumberToWordsConverter.Models;
using NumberToWordsConverter.Services;
using NUnit.Framework;
using System;

namespace NumberToWordsConverter.Tests
{
    [TestFixture]
    public class NumberToWordsServiceTest
    {
        private NumberToWordsService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new NumberToWordsService(new CurrencyParser(), new CurrencyOutputFormatter(), new NumberTranslator(), new ServiceConfigurations());
        }

        [Test]
        public void ConvertToWords_DollarAndCents_ShouldReturn_ValidText()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(100.55)
            };

            //Action
            var result = _service.ConvertToWords(model);

            //Assert
            Assert.AreEqual(result.CurrencyInWords, "ONE HUNDRED DOLLARS AND FIFTY-FIVE CENTS");
        }

        [Test]
        public void ConvertToWords_OnlyDollar_ShouldReturn_ValidText()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(100)
            };

            //Action
            var result = _service.ConvertToWords(model);

            //Assert
            Assert.AreEqual(result.CurrencyInWords, "ONE HUNDRED DOLLARS");
        }

        [Test]
        public void ConvertToWords_Million_ShouldReturn_ValidText()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(9000000)
            };

            //Action
            var result = _service.ConvertToWords(model);

            //Assert
            Assert.AreEqual(result.CurrencyInWords, "NINE MILLION DOLLARS");
        }

        [Test]
        public void ConvertToWords_Thousands_ShouldReturn_ValidText()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(999000)
            };

            //Action
            var result = _service.ConvertToWords(model);

            //Assert
            Assert.AreEqual(result.CurrencyInWords, "NINE HUNDRED AND NINETY-NINE THOUSAND DOLLARS");
        }

        [Test]
        public void ConvertToWords_MaxValue_ShouldReturn_ValidText()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(9999999.99)
            };

            //Action
            var result = _service.ConvertToWords(model);

            //Assert
            Assert.AreEqual(result.CurrencyInWords, "NINE MILLION AND NINE HUNDRED AND NINETY-NINE THOUSAND AND NINE HUNDRED AND NINETY-NINE DOLLARS AND NINETY-NINE CENTS");
        }

        [Test]
        public void ConvertToWords_NegativeValue_ShouldReturn_ArgumentOfRangeException()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(-1)
            };

            //Action
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.ConvertToWords(model));
        }

        [Test]
        public void ConvertToWords_GreaterThanMillion_ShouldReturn_ArgumentOfRangeException()
        {
            //Arrange
            var model = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(9999999.99 + 1)
            };

            //Action
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.ConvertToWords(model));
        }
    }
}
