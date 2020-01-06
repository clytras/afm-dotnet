using System;
using System.Collections.Generic;
using System.Text;

namespace Lytrax.AFM
{
    /// <summary>
    /// Class with static methods to generate valid or invalid AFM numbers
    /// </summary>
    public class GenerateAFM
    {
        /// <summary>
        /// Generates an AFM number based on parameters
        /// </summary>
        /// <param name="forceFirstDigit">If specified, overrides all pre99, legalEntity and individual</param>
        /// <param name="pre99">Για ΑΦΜ πριν από 1/1/1999 (ξεκινάει με 0), (if true, overrides both legalEntity and individual)</param>
        /// <param name="individual">Φυσικά πρόσωπα (ξεκινάει με 1-4)</param>
        /// <param name="legalEntity">Νομικές οντότητες (ξεκινάει με 7-9)</param>
        /// <param name="repeatTolerance">Number for max repeat tolerance (0 for no repeats, unspecified for no check)</param>
        /// <param name="valid">Generate valid or invalid AFM</param>
        /// <returns>A valid or invalid 9 digit AFM number</returns>
        public static string Generate(
            int? forceFirstDigit = null,
            bool pre99 = false,
            bool individual = false,
            bool legalEntity = false,
            int? repeatTolerance = null,
            bool valid = true
        )
        {
            int min = legalEntity ? 7 : 1;
            int max = individual ? 4 : 9;
            int? repeatOf = repeatTolerance;
            int digit = forceFirstDigit.HasValue ? (int)forceFirstDigit :
                (pre99 ?
                    0 :
                    Utils.GetRandomInt(min, max)
                );
            int lastGenDigit = digit;
            int repeats = 0;
            string body = digit.ToString();
            int sum = digit * 0x100;

            for(int i = 7; i >= 1; i--)
            {
                digit = Utils.GetRandomInt(0, 9,
                    repeatOf.HasValue && repeats >= repeatOf ? 
                        (int?)lastGenDigit : 
                        null
                );
                body += digit.ToString();
                sum += digit << i;
                if (digit == lastGenDigit)
                    repeats++;
                else
                    repeats = 0;
                lastGenDigit = digit;
            }

            int validator = sum % 11;
            int d9Valid = validator % 10;
            int d9 = valid ? d9Valid : Utils.GetRandomInt(0, 9, (int?)d9Valid);

            return body + d9;
        }

        /// <summary>
        /// Generates a valid AFM number based on parameters
        /// </summary>
        /// <param name="forceFirstDigit">If specified, overrides all pre99, legalEntity and individual</param>
        /// <param name="pre99">Για ΑΦΜ πριν από 1/1/1999 (ξεκινάει με 0), (if true, overrides both legalEntity and individual)</param>
        /// <param name="individual">Φυσικά πρόσωπα, (ξεκινάει με 1-4)</param>
        /// <param name="legalEntity">Νομικές οντότητες (ξεκινάει με 7-9)</param>
        /// <param name="repeatTolerance">Number for max repeat tolerance (0 for no repeats, unspecified for no check)</param>
        /// <returns>A valid 9 digit AFM number</returns>
        public static string GenerateValid(
            int? forceFirstDigit = null,
            bool pre99 = false,
            bool individual = false,
            bool legalEntity = false,
            int? repeatTolerance = null
        )
        {
            return Generate(forceFirstDigit, pre99, individual, legalEntity, repeatTolerance, true);
        }

        /// <summary>
        /// Generates an invalid AFM number based on parameters
        /// </summary>
        /// <param name="forceFirstDigit">If specified, overrides all pre99, legalEntity and individual</param>
        /// <param name="pre99">Για ΑΦΜ πριν από 1/1/1999 (ξεκινάει με 0), (if true, overrides both legalEntity and individual)</param>
        /// <param name="individual">Φυσικά πρόσωπα, (ξεκινάει με 1-4)</param>
        /// <param name="legalEntity">Νομικές οντότητες (ξεκινάει με 7-9)</param>
        /// <param name="repeatTolerance">Number for max repeat tolerance (0 for no repeats, unspecified for no check)</param>
        /// <returns>An invalid 9 digit AFM number</returns>
        public static string GenerateInvalid(
            int? forceFirstDigit = null,
            bool pre99 = false,
            bool individual = false,
            bool legalEntity = false,
            int? repeatTolerance = null
        )
        {
            return Generate(forceFirstDigit, pre99, individual, legalEntity, repeatTolerance, false);
        }
    }
}
