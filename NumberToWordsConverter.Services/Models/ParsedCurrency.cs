namespace NumberToWordsConverter.Models
{
    /// <summary>
    /// Currency in whole number Dollars and Cents
    /// </summary>
    public class ParsedCurrency
    {
        public int Dollars { get; set; }
        public int Cents { get; set; }
    }
}