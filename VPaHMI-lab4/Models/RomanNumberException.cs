using System;

namespace VPaHMI_lab4
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException() : base("ERROR") { }
        public RomanNumberException(string message) : base(message) { }
    }
}
