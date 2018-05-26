using System;
using System.Collections.Generic;
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
    public class NumberTranslatorTest
    {
        private ITranslateNumber _service;

        [SetUp]
        public void SetUp()
        {
            _service = new NumberTranslator();
        }

        [Test]
        public void Translate_Number_ShoulReturn_ValidText()
        {
            //Arrange
            var number = 100;

            //Action            
            var result = _service.Translate(number);

            //Assert
            Assert.AreEqual(result, "hundred");
        }

        [Test]
        public void Tranlate_MillionNumber_ShoulReturn_ValidText()
        {
            //Arrange
            var number = 1000000;

            //Action            
            var result = _service.Translate(number);

            //Assert
            Assert.AreEqual(result, "million");
        }

        [Test]
        public void Tranlate_Tens_ShoulReturn_ValidText()
        {
            //Arrange
            var number = 90;

            //Action            
            var result = _service.Translate(number);

            //Assert
            Assert.AreEqual(result, "ninety");
        }

        [Test]
        public void Tranlate_Twenties_ShoulReturn_ValidText()
        {
            //Arrange
            var number = 15;

            //Action            
            var result = _service.Translate(number);

            //Assert
            Assert.AreEqual(result, "fifteen");
        }

        [Test]
        public void Tranlate_Throws_KeyNotFoundException()
        {
            //Arrange
            var number = 99;

            //Action            
            //Assert
            Assert.Throws<KeyNotFoundException>(() =>_service.Translate(number));
        }
    }
}
