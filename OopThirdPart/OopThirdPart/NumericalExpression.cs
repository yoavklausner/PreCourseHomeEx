using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OopThirdPart
{
    internal class NumericalExpression
    {


        private readonly ulong  _value;

        private static readonly string[] _unitsExps =
        {
            "one ",
            "two ",
            "three ",
            "four ",
            "five ",
            "six ",
            "seven ",
            "eight ",
            "nine "
        };

        // hash for efficient three digits numbers sum letters 
        private static Dictionary<(ushort, byte), uint> _threeDigitsSumLetters = new Dictionary<(ushort, byte), uint>();


        private static Dictionary<string, Func<ushort, byte, string>> _languageConverters = new();

        private readonly string _language;

        private readonly string[] _powersOfThousand =
        [
            "",
            "thousand ",
            "million ",
            "billion "
        ];
        private static readonly string ENGLISH = "English";

        #region C'tors
        public NumericalExpression(ulong value)
        {
            _value = value%1000000000000;
            if (!_languageConverters.ContainsKey(ENGLISH))
                _languageConverters.Add(ENGLISH, GetEnglishNextThreeDigits);
            _language = ENGLISH;
        }

        public NumericalExpression(ulong value, string[] powersOfThousand)
        {
            _value = value % (ulong)Math.Pow(1000, powersOfThousand.Length);
            if (!_languageConverters.ContainsKey(ENGLISH))
                _languageConverters.Add(ENGLISH, GetEnglishNextThreeDigits);
            _language = ENGLISH;
            _powersOfThousand = powersOfThousand;
        }

        public NumericalExpression(ulong value, string language)
        {
            _value = value;
            if (!_languageConverters.ContainsKey(language)) throw new ArgumentException($"A converter for {language} not exists.");
            _language = language;
        }

        public NumericalExpression(ulong value, string language, Func<ushort, byte, string> nextThreeDigitsConverter) 
        {
            _value = value;
            if (_languageConverters.ContainsKey(language)) throw new ArgumentException($"A converter for {language} alerady exists.");
            _languageConverters.Add(language, nextThreeDigitsConverter);
            _language = language;
        }
        #endregion


        private string GetEnglishNextThreeDigits(ushort number, byte power)
        {
            string expression = "";
            byte hundredsDig = (byte)((number / 100) % 10),
                dozensDig = (byte)((number / 10) % 10),
                unitsDig = (byte)(number % 10);
            if (number == 0) return "";
            if (hundredsDig != 0) expression += _unitsExps[hundredsDig - 1] + "hundred ";
            switch (dozensDig)
            {
                case 0: break;
                case 1:
                    return unitsDig switch
                    {
                        0 => expression + "ten " + _powersOfThousand[power],
                        1 => expression + "eleven " + _powersOfThousand[power],
                        2 => expression + "twelve " + _powersOfThousand[power],
                        3 => expression + "thirteen " + _powersOfThousand[power],
                        5 => expression + "fifteen " + _powersOfThousand[power],
                        8 => expression + "eighteen " + _powersOfThousand[power],
                        _ => expression + _unitsExps[unitsDig - 1] + "\bteen " + _powersOfThousand[power],
                    };
                case 2: expression += "twenty "; break;
                case 3: expression += "thirty "; break;
                case 4: expression += "forty "; break;
                case 5: expression += "fifty "; break;
                case 8: expression += "eighty "; break;
                default: expression += _unitsExps[dozensDig - 1] + "\bty "; break;
            }
            return expression + (unitsDig != 0 ? _unitsExps[unitsDig - 1] : " ") + _powersOfThousand[power];
        }


        private static ushort GetExpDigitCount(ulong number, string language)
        {
            return (ushort)(new NumericalExpression(number, language).ToString()!.Replace("\b", "").Replace(" ", "").Length);
        }


        private static uint SumLettersThreeDigit(ushort number, byte power, string language)
        {
            uint sumLetters = 0;
            if (_threeDigitsSumLetters.TryGetValue((number, power), out uint value)) return value;
            for (int i = 1; i <= number; i++) 
                sumLetters += GetExpDigitCount((ulong)i * (ulong)Math.Pow(1000, power), language);
            _threeDigitsSumLetters.Add((number, power), sumLetters);
            return sumLetters;
        } 

        private static byte GetTopPower(ulong number)
        {
            byte power = 0;
            while ((number /= 1000) != 0) power++;
            return power;
        }


        //the oop concept that is used here is polymorphism
        //because the method overloading technique is based on polymorphism
        public static ulong SumLetters(ulong number, string language)
        {
            ulong sumLetters = 0;
            ushort topPower = GetTopPower(number);
            short currentPower = (short)topPower;
            while (currentPower != -1)
            {
                ulong thousandPower = (ulong)Math.Pow(1000, currentPower);
                ushort currentThreeDigit = (ushort)((number/thousandPower)%1000);
                if (currentThreeDigit != 0)
                    sumLetters += GetExpDigitCount((ulong)currentThreeDigit*thousandPower, language) * (number%thousandPower +1)+
                    (ulong)SumLettersThreeDigit((ushort)(currentThreeDigit-1), (byte)currentPower, language)*
                    thousandPower;
                currentPower--;
            }
            for (byte i = 0; i < topPower; i++)
                sumLetters += SumLettersThreeDigit(999, i, language) * 
                    (number / (ulong)Math.Pow(1000, i + 1)) * 
                    (ulong)Math.Pow(1000, i);
            return sumLetters + 4; // plus 4 for "zero"
        }

        public static ulong SumLetters(NumericalExpression numExp)
        {
            return SumLetters(numExp.GetValue(), numExp.GetLanguage());
        }

        public static ulong SumLetters(ulong number)
        {
            return SumLetters(number, ENGLISH);
        }

        public ulong GetValue() => _value;

        public string GetLanguage() => _language;

        public override string ToString()
        {
            string numExp = "";
            byte power = 0;
            ulong number = _value;
            while (number != 0)
            {
                numExp = _languageConverters[_language]((ushort)(number % 1000), power) + numExp;
                power++;
                number /= 1000;
            }
            return numExp;
        }
    }
}
