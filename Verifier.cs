using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATMProject
{
    static class Verifier
    {
        public static bool digitVerifier(string input,int numberOfDigit)
        {
            return input.Length == numberOfDigit ? true : false;
        }
        public static bool IsNumber(string input)
        {
            return Int32.TryParse(input, out int result);
        }
    }
}
