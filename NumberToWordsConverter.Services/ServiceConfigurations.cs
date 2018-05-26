namespace NumberToWordsConverter.Services
{
    /// <summary>
    /// Provides Service Configurations
    /// </summary>
    public class ServiceConfigurations : IServiceConfigurations
    {
        public readonly string unitsSepartor = "and";
        public readonly string connector = "-";
        public readonly decimal maxSupportedValue = new decimal(9999999.99);

        public string CurrencyUnitsSepartor
        {
            get { return unitsSepartor; }
        }

        public string CurrencyUnitsConnector
        {
            get { return connector; }
        }

        public decimal MaxSupportedValue
        {
            get { return maxSupportedValue; }
        }
    }
}
