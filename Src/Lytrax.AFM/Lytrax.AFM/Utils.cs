using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Lytrax.AFM.Tests")]

namespace Lytrax.AFM
{
    internal class Utils
    {
        public static int GetRandomInt(
            int min, 
            int max, 
            int? notEqual = null
        )
        {
            System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
            int result;

            do
                result = rnd.Next(min, max - 1);
            while (notEqual.HasValue && result == (int)notEqual);

            return result;
        }
    }
}
