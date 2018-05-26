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

namespace NumberToWordsConverter.Tests.Controllers
{
    [TestFixture]
    public class CurrencyConverterControllerTest
    {
        private CurrencyConverterController _controller;
        private INumberToWordsService _service;

        [SetUp]
        public void SetUp()
        {
            _service = Substitute.For<INumberToWordsService>();
            _controller = new CurrencyConverterController(_service);

            //setup controller with default request and configuration
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [Test]
        public void Call_ConvertCurrency_ShoulReturn_CurrencyInWords()
        {
            //Arrange
            var requestCurrencyModel = new RequestCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                Currency = new decimal(123.45)
            };

            var wordsCurrencyModel = new ResponseCurrencyModel
            {
                Name = "Muhammad Zeeshan",
                CurrencyInWords = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"
            };
            _service.ConvertToWords(Arg.Any<RequestCurrencyModel>()).Returns(wordsCurrencyModel);

            //Action            
            var response = _controller.Post(requestCurrencyModel).ExecuteAsync(CancellationToken.None).Result;
            var result = JsonConvert.DeserializeObject<ResponseCurrencyModel>(response.Content.ReadAsStringAsync().Result);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result.Name, "Muhammad Zeeshan");
            Assert.AreEqual(result.CurrencyInWords, "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS");
        }
    }
}
