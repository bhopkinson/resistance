using System;
using System.Linq;

namespace Resistance.Web.Services
{
    public class CodeGenerator : ICodeGenerator
    {
        private const int Length = 4;
        private readonly Random _random = new Random();
        private readonly string _chars = "0123456789";

        public string GetCode()
            => new string(
                Enumerable.Range(0, Length)
                .Select(o => GetChar())
                .ToArray());
        
         private char GetChar()
            => _chars[_random.Next(_chars.Length)];
    }
}
