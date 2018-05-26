using System;
using System.Collections.Generic;

namespace NumberToWordsConverter.Services
{
    /// <summary>
    /// Provides numbers to text translations. This can abstract out the logic for localizing our resources in future
    /// </summary>
    public class TranslateNumber : ITranslateNumber
    {
        private Dictionary<Int64, string> _uniqueTextsForNumbers;

        public TranslateNumber()
        {
            Init();
        }

        public string Translate(Int64 number)
        {
            return _uniqueTextsForNumbers[number];
        }

        private void Init()
        {
            _uniqueTextsForNumbers = new Dictionary<long, string>
            {
                {0, "zero"},
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eighteen"},
                {19, "nineteen"},
                {20, "twenty"},
                {30, "thirty"},
                {40, "forty"},
                {50, "fifty"},
                {60, "sixty"},
                {70, "seventy"},
                {80, "eighty"},
                {90, "ninety"},
                {100, "hundred"},
                {1000, "thousand"},
                {1000000, "million"},
                {1000000000, "billion"}
            };
        }
    }    
}