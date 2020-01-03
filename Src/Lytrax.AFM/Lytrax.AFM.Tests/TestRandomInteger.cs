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
                    string.Format(Messages.MessageNotBetween, value));
            }
        }

        [TestMethod]
        public void TestGenerateIntegersWithRangeExcludingSpecificDigits()
        {
            for (int i = 0; i < Helpers.Iterations; i++)
            {
                for(int notEqual = 0; notEqual <= 9; notEqual++)
                {
                    int value = Utils.GetRandomInt(0, 9, notEqual);
                    Assert.IsTrue(value >= 0 && value <= 9,
                        string.Format(Messages.MessageNotBetween, value));
                    Assert.AreNotEqual(notEqual, value,
                        string.Format(Messages.MessageFailNotEqual, value, notEqual));
                }
            }
        }
    }
}
