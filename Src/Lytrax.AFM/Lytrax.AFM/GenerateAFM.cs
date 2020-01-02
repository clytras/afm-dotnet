using System;
using System.Collections.Generic;
using System.Text;

namespace Lytrax.AFM
{
    class GenerateAFM
    {
        GenerateAFM(
            int? forceFirstDigit = null,
            bool pre99 = false,
            bool individual = false,
            bool legalEntity = false,
            int? repeatTolerance = null,
            bool valid = true
        )
        {
            ForceFirstDigit = forceFirstDigit;
            Pre99 = pre99;
            Individual = individual;
            LegalEntity = legalEntity;
            RepeatTolerance = repeatTolerance;
            Valid = valid;
        }

        public static string GenerateStatic(
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
            int d9Valid = validator >= 10 ? 0 : validator;
            int d9 = valid ? d9Valid : Utils.GetRandomInt(0, 0, (int?)d9Valid);

            return body + d9;
        }

        public int? ForceFirstDigit { get; set; }
        public bool Pre99 { get; set; }
        public bool Individual { get; set; }
        public bool LegalEntity { get; set; }
        public int? RepeatTolerance { get; set; }
        public bool Valid { get; set; }
    }
}
