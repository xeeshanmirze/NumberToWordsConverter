namespace NumberToWordsConverter.Services
{
    /// <summary>
    /// Formats dollars and cents for resoponse
    /// </summary>
    public class CurrencyOutputFormatter : ICurrencyOutputFormatter
    {
        public string Format(string dollars, string cents)
        {
            if (string.IsNullOrWhiteSpace(cents))
            {
                return $"{dollars.Trim()} Dollars".ToUpper();
            }
            return $"{dollars.Trim()} Dollars and {cents.Trim()} Cents".ToUpper();
        }
    }

}