using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Newtonsoft.Json;
using NSubstitute;
using NumberToWordsConverter.Models;
using NumberToWordsConverter.Services;
using NUnit.Framework;
using Zeeshan.NumberToWordsConverter.Controllers;

namespace NumberToWordsConverter.Tests
{
    [TestFixture]
    public class CurrencyOutputFormatterTest
    {
        private ICurrencyOutputFormatter _formatterService;

        [SetUp]
        public void SetUp()
        {
            _formatterService = new CurrencyOutputFormatter();
        }

        [Test]
        public void FormatCurrency_DollarAndCents_ShoulReturn_FormattedCurrency()
        {
            //Arrange
            var dollars = "one hundred and twnety-three";
            var cents = "forty-five";

            //Action            
            var result = _formatterService.Format(dollars, cents);

            //Assert
            Assert.AreEqual(result, "ONE HUNDRED AND TWNETY-THREE DOLLARS AND FORTY-FIVE CENTS");
        }

        [Test]
        public void FormatCurrency_DollarOnly_ShoulReturn_FormattedCurrencyWithoutCents()
        {
            //Arrange
            var dollars = "one hundred and twnety-three";
            var cents = string.Empty;

            //Action            
            var result = _formatterService.Format(dollars, cents);

            //Assert
            Assert.AreEqual(result, "ONE HUNDRED AND TWNETY-THREE DOLLARS");
        }
    }
}
