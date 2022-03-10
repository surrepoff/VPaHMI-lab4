using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VPaHMI_lab4.Models
{
    public static class RomanNumberCalculator
    {

        private static ushort CheckOperator(string input)
        {
            if (input.Count(f => f == '+') + input.Count(f => f == '-') + input.Count(f => f == '*') + input.Count(f => f == '/') == 1)
            {
                if (input.Count(f => f == '+') == 1) return 1;
                if (input.Count(f => f == '-') == 1) return 2;
                if (input.Count(f => f == '*') == 1) return 3;
                if (input.Count(f => f == '/') == 1) return 4;
            }
            return 0;
        }

        public static RomanNumberExtend Calculate(string input)
        {
            ushort _operator = CheckOperator(input);
            if (_operator == 0) throw new RomanNumberException("ERROR: Invalid input");
            string[] number = input.Split('+', '-', '*', '/');
            if (!RomanNumberExtend.CheckString(number[0])) throw new RomanNumberException("ERROR: Invalid input");
            if (!RomanNumberExtend.CheckString(number[2])) throw new RomanNumberException("ERROR: Invalid input");

            switch (_operator)
            {
                case 1: return (RomanNumberExtend)(new RomanNumberExtend(RomanNumberExtend.ToUshort(number[0])) + new RomanNumberExtend(RomanNumberExtend.ToUshort(number[1])));
                case 2: return (RomanNumberExtend)(new RomanNumberExtend(RomanNumberExtend.ToUshort(number[0])) - new RomanNumberExtend(RomanNumberExtend.ToUshort(number[1])));
                case 3: return (RomanNumberExtend)(new RomanNumberExtend(RomanNumberExtend.ToUshort(number[0])) * new RomanNumberExtend(RomanNumberExtend.ToUshort(number[1])));
                case 4: return (RomanNumberExtend)(new RomanNumberExtend(RomanNumberExtend.ToUshort(number[0])) / new RomanNumberExtend(RomanNumberExtend.ToUshort(number[1])));
                default:
                    break;
            }
            return new RomanNumberExtend(0);
        }



    }
}
