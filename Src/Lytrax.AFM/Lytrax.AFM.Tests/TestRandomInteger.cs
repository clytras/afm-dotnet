using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lytrax.AFM;

namespace Lytrax.AFM.Tests
{
    [TestClass]
    public class TestRandomInteger
    {
        [TestMethod]
        public void TestGenerateIntegersWithRange()
        {
            for(int i = 0; i < Helpers.Iterations; i++)
            {
                int value = Utils.GetRandomInt(0, 9);
                Assert.IsTrue(value >= 0 && value <= 9,
                    string.Format(Helpers.MessageNotBetween, value));
            }
        }

        [TestMethod]
        public void TestGenerateIntegersWithRangeExcludingSpecificDigits()
        {
            int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < Helpers.Iterations; i++)
            {
                foreach(int notEqual in digits)
                {
                    int value = Utils.GetRandomInt(0, 9, notEqual);
                    Assert.IsTrue(value >= 0 && value <= 9,
                        string.Format(Helpers.MessageNotBetween, value));
                    Assert.AreNotEqual(notEqual, value,
                        string.Format(Helpers.MessageFailNotEqual, value, notEqual));
                }
            }
        }
    }
}
