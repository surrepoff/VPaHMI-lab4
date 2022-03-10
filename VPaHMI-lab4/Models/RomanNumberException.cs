using System;

namespace VPaHMI_lab4.Models
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException() : base("ERROR") { }
        public RomanNumberException(string message) : base(message) { }
    }
}
