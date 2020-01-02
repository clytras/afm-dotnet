using System.Collections.Generic;

namespace Lytrax.AFM.Tests
{
    class Helpers
    {
        public static readonly int Iterations = 100;

        public static readonly string[] StaticValidNumbers = new string[]
        {
            "090000045", // DEI
            "094019245", // OTE
            "094079101", // EYDAP
        };

        public static readonly string[] StaticInvalidNumbers = new string[]
        {
            "123456789",
            "097364585",
            "150663780",
        };

        public static readonly Dictionary<string, string> InvalidErrors = new Dictionary<string, string>()
        {
            ["length"] = "09000004",
            ["nan"] = "09000004A",
            ["zero"] = "000000000",
            ["invalid"] = "123456789"
        };

        public static readonly string MessageNotBetween = "GetRandomInt return an int not between 0 and 9 (returned = {0})";
        public static readonly string MessageFailNotEqual = "GetRandomInt return an int equal to notEqual (returned = {0}, notEqual = {1})";
        public static readonly string MessageNotValidated = "Validate does not validate valid number (number = {0})";
        public static readonly string MessageNotInvalidated = "Validate does not invalidate invalid number (number = {0})";
        public static readonly string MessageClassInstanceNotEqualNumber = "ValidateAFM class instance Number not equal number (.Number = {0}, number = {1})";
        public static readonly string MessageClassInstanceErrorShouldBe = "ValidateAFM class instance Error should be \"{0}\" (.Error = \"{1}\")";
    }
}
