using System;

namespace NumberToWordsConverter.Services
{
    public interface ITranslateNumber
    {       
        string Translate(Int64 number);
    }
}