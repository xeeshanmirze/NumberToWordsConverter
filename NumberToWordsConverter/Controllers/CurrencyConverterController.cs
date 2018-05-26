using NumberToWordsConverter.Models;
using NumberToWordsConverter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Zeeshan.NumberToWordsConverter.Controllers
{
    public class CurrencyConverterController : ApiController
    {
        private readonly INumberToWordsService _numberToWordsService;
        public CurrencyConverterController(INumberToWordsService service)
        {
            _numberToWordsService = service;
        }

        [HttpPost]
        public IHttpActionResult Post(RequestCurrencyModel model)
        {
            return Ok(_numberToWordsService.ConvertToWords(model));
        }
    }
}
