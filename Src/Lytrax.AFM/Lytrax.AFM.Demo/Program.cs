using System;
using System.Linq;

using Lytrax.AFM;

namespace Lytrax.AFM.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid = ValidateAFM.Validate("130558797");
            Console.WriteLine(valid ? "Valid" : "Invalid");

            int? test = null;

            Console.WriteLine(test.HasValue ? "Has" : "Has not");
        }
    }
}
