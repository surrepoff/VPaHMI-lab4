using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VPaHMI_lab4.Models
{
    public class RomanNumberExtend: RomanNumber
    {
        public ushort UshortValue() => this._number;
        public RomanNumberExtend(ushort number) : base(number) {}
        public RomanNumberExtend(string number) : base(ToUshort(number)) { }

        public static bool CheckString (string number)
        {
            Regex regex = new("^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            return regex.IsMatch(number);
        }

        private static ushort CharValue(char с)
        {
            return с switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new RomanNumberException("ERROR: Invalid char"),
            };
        }

        public static ushort ToUshort(string n)
        {
            if (!CheckString(n)) throw new RomanNumberException("ERROR: Invalid input");

            ushort total = 0;
            for (int i = 0; i < n.Length; i++)
            {
                ushort current = CharValue(n[i]);
                if (i + 1 < n.Length)
                {
                    if (current >= CharValue(n[i + 1])) total = (ushort)(total + current);
                    else total = (ushort)(total - current);
                }
                else
                {
                    total = (ushort)(total + current);
                }
            }
            return total;
        }
    }
}
