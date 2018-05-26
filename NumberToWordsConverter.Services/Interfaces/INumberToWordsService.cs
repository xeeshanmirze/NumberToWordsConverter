using NumberToWordsConverter.Models;

namespace NumberToWordsConverter.Services
{
    public interface INumberToWordsService
    {
        ResponseCurrencyModel ConvertToWords(RequestCurrencyModel model);
    }
}