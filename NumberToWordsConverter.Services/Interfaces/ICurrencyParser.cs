using NumberToWordsConverter.Models;

namespace NumberToWordsConverter.Services
{
    public interface ICurrencyParser
    {
        ParsedCurrency Parse(decimal amount);
    }
}