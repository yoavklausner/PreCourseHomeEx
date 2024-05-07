using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OopThirdPart
{
    class NumericalExpression
    {

        protected readonly long _number;
        public NumericalExpression(long number) { _number = number; }


        public long Number => _number;

        private static string GetDigitLiteral(int digit)
        {
            switch (digit)
            {
                case 1: return "one "; 
                case 2: return "two "; 
                case 3: return "three "; 
                case 4: return "four "; 
                case 5: return "five "; 
                case 6: return "six "; 
                case 7: return "seven ";
                case 8: return "eight ";
                case 9: return "nine ";
            }
            return "";
        }

        private static string GetHundredsLiteral(int number)
        {
            string literalNumber = "";
            int hundreds = (number / 100) % 100, dozens = (number / 10) % 10, units = number % 10;
            if (hundreds != 0) literalNumber += GetDigitLiteral(hundreds)+"hundred ";
            if (dozens == 1)
            {
                if (units == 0) literalNumber += "ten ";
                else if (units == 1) literalNumber += "eleven ";
                else if (units == 2) literalNumber += "twelve ";
                else if (units == 3) literalNumber += "thirteen ";
                else if (units == 5) literalNumber += "fifteen ";
                else literalNumber += " " + GetDigitLiteral(units) + "\bteen ";
            }
            else if (dozens == 2) literalNumber += "twenty ";
            else if (dozens == 3) literalNumber += "thirty ";
            else if (dozens == 5) literalNumber += "fifty ";
            else if (dozens != 0) literalNumber += GetDigitLiteral(dozens) + "\bty ";
            if (dozens != 1 && units != 0) literalNumber += GetDigitLiteral(units);
            return literalNumber;
        }

        private string GetLiteral()
        {
            string literalNumber = "";
            int trilion = (int)(_number / 1000000000000)%1000,
            bilion = (int)(_number / 1000000000) % 1000,
            milion = (int)(_number / 1000000) % 1000,
            thousand = (int)(_number / 1000) % 1000,
            unit = (int)(_number % 1000);
            if (trilion != 0) literalNumber += GetHundredsLiteral(trilion) + "trillion, ";
            if (bilion != 0) literalNumber += GetHundredsLiteral(bilion) + "billion, ";
            if (milion != 0) literalNumber += GetHundredsLiteral(milion) + "million, ";
            if (thousand != 0) literalNumber += GetHundredsLiteral(thousand) + "thousand, ";
            if (unit != 0) literalNumber += GetHundredsLiteral(unit);
            return literalNumber;
        }

        public static int SumLetters(int number)
        {
            NumericalExpression numExp = new NumericalExpression(number);
            return SumLetters(numExp);
        }

        //the oop concept is method overloading
        //which give the power to declare two methods with the same name but different params
        public static int SumLetters(NumericalExpression numExp)
        {
            string literal = numExp.ToString();
            return literal.Replace("\b", "").Replace(" ", "").Replace("," , "").Length;
        }

        public override string ToString()
        {
            if (Number == 0) return "zero";
            else return GetLiteral();
        }
    }
}
