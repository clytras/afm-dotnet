using System;
using System.Text.RegularExpressions;

namespace Lytrax.AFM
{
    public class ValidateAFM
    {
        private string afm;

        public ValidateAFM(string afm)
        {
            ValidateAFMExtendedResult result = ValidateExtended(afm);

            Number = afm;
            Valid = result.Valid;
            Error = result.Error;
        }

        public static bool Validate(string afm)
        {
            ValidateAFMExtendedResult result = ValidateExtended(afm);
            return result.Valid;
        }

        public static ValidateAFMExtendedResult ValidateExtended(string afm)
        {
            if (afm == null)
            {
                throw new ArgumentNullException("AFM number is not initialized");
            }

            if (afm.Length != 9)
            {
                return new ValidateAFMExtendedResult(false, "length");
            }

            var isNaNRE = new Regex(@"^\d+$");
            if (!isNaNRE.IsMatch(afm))
            {
                return new ValidateAFMExtendedResult(false, "nan");
            }

            if (afm == "000000000")
            {
                return new ValidateAFMExtendedResult(false, "zero");
            }

            string body = afm.Substring(0, 8);
            int sum = 0;

            for(int i = 0; i < body.Length; i++)
            {
                int digit = int.Parse(body[i].ToString());
                sum += digit << (8 - i);
            }

            int calc = sum % 11;
            int d9 = int.Parse(afm[8].ToString());
            bool valid = calc % 10 == d9;

            return new ValidateAFMExtendedResult(valid, valid ? "" : "invalid");
        }

        public string Number { get; private set; }
        public bool Valid { get; private set; } = false;
        public String Error { get; private set; }
    }

    public class ValidateAFMExtendedResult
    {
        public ValidateAFMExtendedResult(bool valid, string error = "")
        {
            Valid = valid;
            Error = error;
        }
        public bool Valid { get; private set; }
        public string Error { get; private set; }
    }
}
