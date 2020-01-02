using System;
using System.Linq;

using Lytrax.AFM;

namespace Lytrax.AFM.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo: Generate valid numbers");

            report("(default)", GenerateAFM.GenerateValid());
            report("pre99", GenerateAFM.GenerateValid(pre99: true));
            report("legalEntity", GenerateAFM.GenerateValid(legalEntity: true));
            report("individual", GenerateAFM.GenerateValid(individual: true));
            report("repeatTolerance:0", GenerateAFM.GenerateValid(repeatTolerance: 0));

            Console.WriteLine();
            Console.WriteLine("Demo: Generate invalid numbers");

            report("(default)", GenerateAFM.GenerateInvalid());
            report("pre99", GenerateAFM.GenerateInvalid(pre99: true));
            report("legalEntity", GenerateAFM.GenerateInvalid(legalEntity: true));
            report("individual", GenerateAFM.GenerateInvalid(individual: true));
            report("repeatTolerance:0", GenerateAFM.GenerateInvalid(repeatTolerance: 0));
        }

        static void report(string label, string number)
        {
            Console.WriteLine("{0} {1} {2}", label, number, validator(ValidateAFM.Validate(number)));
        }

        static string validator(bool valid)
        {
            return valid ? "(valid)" : "(invalid)";
        }
    }
}
