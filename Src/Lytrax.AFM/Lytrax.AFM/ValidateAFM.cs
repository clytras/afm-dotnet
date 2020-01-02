using System;
using System.Text.RegularExpressions;

namespace Lytrax.AFM
{
    public class ValidateAFM
    {
        /// <summary>
        /// The object constructor initializes and immediately validates an AFM number
        /// </summary>
        /// <param name="afm">A string to be check if it's a valid AFM</param>
        public ValidateAFM(string afm)
        {
            var result = ValidateExtended(afm);

            Number = afm;
            Valid = result.Valid;
            Error = result.Error;
        }

        /// <summary>
        /// Checks if the passed AFM is a valid AFM number
        /// </summary>
        /// <param name="afm">A string to be check if it's a valid AFM</param>
        /// <returns>A boolean result indicating the validation of the number</returns>
        public static bool Validate(string afm)
        {
            var result = ValidateExtended(afm);
            return result.Valid;
        }

        /// <summary>
        /// Checks if the passed AFM is a valid AFM number
        /// </summary>
        /// <param name="afm">A string to be check if it's a valid AFM</param>
        /// <returns>A ValidateAFMExtendedResult result indicating the validation of the number</returns>
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

        /// <value>The current AFM number the class object contains</value>
        public string Number { get; private set; }

        /// <value>A boolean result indicating the validation of the current number the class object contains</value>
        public bool Valid { get; private set; } = false;

        /// <value>A string result indicating the error if the current number the class object is invalid.
        /// It can be "length" or "nan" or "zero" or "invalid"</value>
        public string Error { get; private set; }
    }

    public class ValidateAFMExtendedResult
    {
        /// <summary>
        /// The object constructor initializes a ValidateAFMExtendedResult
        /// </summary>
        /// <param name="valid">Boolean indicates whether a number is valid or not</param>
        /// <param name="error">A string indicating the error if the number is invalid.
        /// It can be "length" or "nan" or "zero" or "invalid"</param>
        public ValidateAFMExtendedResult(bool valid, string error = "")
        {
            Valid = valid;
            Error = error;
        }

        /// <value>Boolean indicates whether a number is valid or not</value>
        public bool Valid { get; private set; }

        /// <value>A string indicating the error if the number is invalid.
        /// It can be "length" or "nan" or "zero" or "invalid"</value>
        public string Error { get; private set; }
    }
}
