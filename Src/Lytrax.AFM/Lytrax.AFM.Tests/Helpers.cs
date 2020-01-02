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
    }
}
