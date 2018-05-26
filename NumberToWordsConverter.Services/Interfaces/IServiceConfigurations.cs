using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordsConverter.Services
{
    public interface IServiceConfigurations
    {
        string CurrencyUnitsSepartor { get; }
        string CurrencyUnitsConnector { get; }
        decimal MaxSupportedValue { get; }
    }
}
