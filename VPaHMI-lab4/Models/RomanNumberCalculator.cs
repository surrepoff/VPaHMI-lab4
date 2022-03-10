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
        public static RomanNumberExtend Calculate(string input)
        {
            var splittedInputByOperands = Regex.Split(input, @"([*()\^\/]|(?<!E)[\+\-])");

            string output = "";
            foreach (var element in splittedInputByOperands)
            {
                if (element != "+" && element != "-" && element != "*" && element != "/")
                {
                    if (!RomanNumberExtend.CheckString(element)) throw new RomanNumberException("Invalid input");
                    output += (new RomanNumberExtend(element)).UshortValue().ToString();
                }
                else output += element;
            }
            DataTable dt = new();
            return new RomanNumberExtend(Convert.ToUInt16(dt.Compute(output, "")));
        }
    }
}
