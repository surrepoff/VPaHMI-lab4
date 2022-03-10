using System;

namespace VPaHMI_lab4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        protected ushort _number;

        //Конструктор получает число n, которое должен представлять объект класса
        public RomanNumber(ushort number)
        {
            if (number <= 0) throw new RomanNumberException("ERROR: Number less than or equal to 0");
            if (number > 3999) throw new RomanNumberException("ERROR: Number more than 3999");
            _number = number;
        }

        //Сложение римских чисел
        public static RomanNumber operator + (RomanNumber? first, RomanNumber? second)
        {
            if (first == null || second == null) throw new RomanNumberException("ERROR: One or more numbers are null");
            return new RomanNumber((ushort)(first._number + second._number));
        }

        //Вычитание римских чисел
        public static RomanNumber operator - (RomanNumber? first, RomanNumber? second)
        {
            if (first == null || second == null) throw new RomanNumberException("ERROR: One or more numbers are null");
            if (first._number <= second._number) throw new RomanNumberException("ERROR: The second number is greater than or equal to the first number");
            return new RomanNumber((ushort)(first._number - second._number));
        }

        //Умножение римских чисел
        public static RomanNumber operator * (RomanNumber? first, RomanNumber? second)
        {
            if (first == null || second == null) throw new RomanNumberException("ERROR: One or more numbers are null");
            if (first._number * second._number == 0) throw new RomanNumberException("ERROR: Result equal to 0");
            return new RomanNumber((ushort)(first._number * second._number));
        }

        //Целочисленное деление римских чисел
        public static RomanNumber operator / (RomanNumber? first, RomanNumber? second)
        {
            if (first == null || second == null) throw new RomanNumberException("ERROR: One or more numbers are null");
            if (first._number / second._number <= 0) throw new RomanNumberException("ERROR: Result less than or equal to 0");
            return new RomanNumber((ushort)(first._number / second._number));
        }

        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            return ToRoman(_number);
        }

        //Рекурсивный перевод в строку
        private static string ToRoman(int number)
        {
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new RomanNumberException();
        }

        //Реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(_number);
        }

        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber num) return _number.CompareTo(num._number);
            else throw new RomanNumberException("ERROR: Invalid argument");
        }
    }
}