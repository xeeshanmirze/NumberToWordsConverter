using System;

namespace NumberToWordsConverter.Services
{
    public interface ITranslateNumber
    {       
        string Translate(int number);
    }
}