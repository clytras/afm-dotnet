using System;
using System.Collections.Generic;
using System.Text;

namespace Lytrax.AFM.Tests
{
    class Messages
    {
        public static readonly string MessageNotBetween = "GetRandomInt return an int not between 0 and 9 (returned = {0})";
        public static readonly string MessageFailNotEqual = "GetRandomInt return an int equal to notEqual (returned = {0}, notEqual = {1})";
        public static readonly string MessageNotValidated = "Validate does not validate valid number (number = \"{0}\")";
        public static readonly string MessageNotInvalidated = "Validate does not invalidate invalid number (number = {0})";
        public static readonly string MessageClassInstanceNotEqualNumber = "ValidateAFM class instance Number not equal number (.Number = \"{0}\", number = \"{1}\")";
        public static readonly string MessageClassInstanceErrorShouldBe = "ValidateAFM class instance Error should be \"{0}\" (.Error = \"{1}\")";
        public static readonly string MessageFirstDigitNotMatch = "Generate first digit should be \"{0}\" (firstDigit = \"{1}\", number = \"{2}\")";
        public static readonly string MessageRepeatToleranceNotExpected = "Generate expected repeat tolerance to be {0} but found {1} repeat(s) (repeatTolerance = {0}, repeats = {1}, body = \"{2}\")";
        public static readonly string MessageRepeatToleranceRepeatExceeded = "Generate repeat tolerance exceeded maximum {0} repeats (repeatTolerance = {0}, repeats = {1}, subject = \"{2}\", body = \"{2}\")";
    }
}
