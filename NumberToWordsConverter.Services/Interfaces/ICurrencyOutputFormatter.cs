using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberToWordsConverter.Services
{
    public interface ICurrencyOutputFormatter
    {
        string Format(string dollars, string cents);
    }

}