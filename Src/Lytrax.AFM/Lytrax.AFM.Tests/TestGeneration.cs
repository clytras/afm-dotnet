using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lytrax.AFM;
using System.Text.RegularExpressions;

namespace Lytrax.AFM.Tests
{
    [TestClass]
    public class TestGeneration
    {
        [TestMethod]
        public void TestDefault()
        {
            for (int i = 0; i < Helpers.Iterations; i++)
            {
                string value = GenerateAFM.Generate();
                bool valid = ValidateAFM.Validate(value);
                Assert.IsTrue(valid, string.Format(Messages.MessageNotValidated, value));

                string valueValid = GenerateAFM.GenerateValid();
                bool validValid = ValidateAFM.Validate(value);
                Assert.IsTrue(validValid, string.Format(Messages.MessageNotValidated, valueValid));

                string valueInvalid = GenerateAFM.GenerateInvalid();
                bool invalidInvalid = ValidateAFM.Validate(valueInvalid);
                Assert.IsFalse(invalidInvalid, string.Format(Messages.MessageNotInvalidated, valueInvalid));
            }
        }

        [TestMethod]
        public void TestForceFirstDigit()
        {
            int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < Helpers.Iterations; i++)
            {
                foreach(int forceFirstDigit in digits)
                {
                    string value = GenerateAFM.Generate(forceFirstDigit: forceFirstDigit);
                    bool valid = ValidateAFM.Validate(value);
                    int firstDigit = int.Parse(value[0].ToString());
                    Assert.IsTrue(valid, string.Format(Messages.MessageNotValidated, value));
                    Assert.AreEqual(forceFirstDigit, firstDigit,
                        string.Format(Messages.MessageFirstDigitNotMatch, forceFirstDigit, firstDigit, value));

                    string valueValid = GenerateAFM.GenerateValid(forceFirstDigit: forceFirstDigit);
                    bool validValid = ValidateAFM.Validate(value);
                    int firstDigitValid = int.Parse(valueValid[0].ToString());
                    Assert.IsTrue(validValid, string.Format(Messages.MessageNotValidated, valueValid));
                    Assert.AreEqual(forceFirstDigit, firstDigitValid,
                        string.Format(Messages.MessageFirstDigitNotMatch, forceFirstDigit, firstDigitValid, valueValid));

                    string valueInvalid = GenerateAFM.GenerateInvalid(forceFirstDigit: forceFirstDigit);
                    bool invalidInvalid = ValidateAFM.Validate(valueInvalid);
                    int firstDigitInvalid = int.Parse(valueInvalid[0].ToString());
                    Assert.IsFalse(invalidInvalid, string.Format(Messages.MessageNotInvalidated, valueInvalid));
                    Assert.AreEqual(forceFirstDigit, firstDigitInvalid,
                        string.Format(Messages.MessageFirstDigitNotMatch, forceFirstDigit, firstDigitInvalid, valueInvalid));
                }
            }
        }

        [TestMethod]
        public void TestPre99()
        {
            int expectedFirstDigit = 0;

            for (int i = 0; i < Helpers.Iterations; i++)
            {
                string value = GenerateAFM.Generate(pre99: true);
                bool valid = ValidateAFM.Validate(value);
                int firstDigit = int.Parse(value[0].ToString());
                Assert.IsTrue(valid, string.Format(Messages.MessageNotValidated, value));
                Assert.AreEqual(expectedFirstDigit, firstDigit,
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigit, value));

                string valueValid = GenerateAFM.GenerateValid(pre99: true);
                bool validValid = ValidateAFM.Validate(value);
                int firstDigitValid = int.Parse(valueValid[0].ToString());
                Assert.IsTrue(validValid, string.Format(Messages.MessageNotValidated, valueValid));
                Assert.AreEqual(expectedFirstDigit, firstDigitValid,
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigitValid, valueValid));

                string valueInvalid = GenerateAFM.GenerateInvalid(pre99: true);
                bool invalidInvalid = ValidateAFM.Validate(valueInvalid);
                int firstDigitInvalid = int.Parse(valueInvalid[0].ToString());
                Assert.IsFalse(invalidInvalid, string.Format(Messages.MessageNotInvalidated, valueInvalid));
                Assert.AreEqual(expectedFirstDigit, firstDigitInvalid,
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigitInvalid, valueInvalid));
            }
        }

        [TestMethod]
        public void TestIndividual()
        {
            string expectedFirstDigit = "1-4";
            var re = new Regex(@"^[1-4]{1}$");

            for (int i = 0; i < Helpers.Iterations; i++)
            {
                string value = GenerateAFM.Generate(individual: true);
                bool valid = ValidateAFM.Validate(value);
                string firstDigit = value[0].ToString();
                Assert.IsTrue(valid, string.Format(Messages.MessageNotValidated, value));
                Assert.IsTrue(re.IsMatch(firstDigit),
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigit, value));

                string valueValid = GenerateAFM.GenerateValid(individual: true);
                bool validValid = ValidateAFM.Validate(value);
                string firstDigitValid = valueValid[0].ToString();
                Assert.IsTrue(validValid, string.Format(Messages.MessageNotValidated, valueValid));
                Assert.IsTrue(re.IsMatch(firstDigitValid),
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigitValid, valueValid));

                string valueInvalid = GenerateAFM.GenerateInvalid(individual: true);
                bool invalidInvalid = ValidateAFM.Validate(valueInvalid);
                string firstDigitInvalid = valueInvalid[0].ToString();
                Assert.IsFalse(invalidInvalid, string.Format(Messages.MessageNotInvalidated, valueInvalid));
                Assert.IsTrue(re.IsMatch(firstDigitInvalid),
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigitInvalid, valueInvalid));
            }
        }

        [TestMethod]
        public void TestLegalEntity()
        {
            string expectedFirstDigit = "7-9";
            var re = new Regex(@"^[7-9]{1}$");

            for (int i = 0; i < Helpers.Iterations; i++)
            {
                string value = GenerateAFM.Generate(legalEntity: true);
                bool valid = ValidateAFM.Validate(value);
                string firstDigit = value[0].ToString();
                Assert.IsTrue(valid, string.Format(Messages.MessageNotValidated, value));
                Assert.IsTrue(re.IsMatch(firstDigit),
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigit, value));

                string valueValid = GenerateAFM.GenerateValid(legalEntity: true);
                bool validValid = ValidateAFM.Validate(value);
                string firstDigitValid = valueValid[0].ToString();
                Assert.IsTrue(validValid, string.Format(Messages.MessageNotValidated, valueValid));
                Assert.IsTrue(re.IsMatch(firstDigitValid),
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigitValid, valueValid));

                string valueInvalid = GenerateAFM.GenerateInvalid(legalEntity: true);
                bool invalidInvalid = ValidateAFM.Validate(valueInvalid);
                string firstDigitInvalid = valueInvalid[0].ToString();
                Assert.IsFalse(invalidInvalid, string.Format(Messages.MessageNotInvalidated, valueInvalid));
                Assert.IsTrue(re.IsMatch(firstDigitInvalid),
                    string.Format(Messages.MessageFirstDigitNotMatch, expectedFirstDigit, firstDigitInvalid, valueInvalid));
            }
        }

        [TestMethod]
        public void TestRepeatTolerance()
        {
            var re = new Regex(@"(.)\1+");

            for (int i = 0; i < Helpers.Iterations; i++)
            {
                for (int repeatTolerance = 0; repeatTolerance <= 3; repeatTolerance++) {
                    string value = GenerateAFM.Generate(repeatTolerance: repeatTolerance);
                    bool valid = ValidateAFM.Validate(value);
                    string body = value.Substring(0, 8);
                    Assert.IsTrue(valid, string.Format(Messages.MessageNotValidated, value));

                    var reMatches = re.Matches(body);
                    if(repeatTolerance == 0)
                    {
                        Assert.AreEqual(0, reMatches.Count,
                            string.Format(Messages.MessageRepeatToleranceNotExpected, repeatTolerance, reMatches.Count, body));
                    } else
                    {
                        foreach(Match repeat in reMatches)
                        {
                            Assert.IsTrue(repeat.Value.Length <= (repeatTolerance + 1),
                                string.Format(Messages.MessageRepeatToleranceRepeatExceeded, repeatTolerance, repeat.Value.Length, repeat.Value, body));
                        }
                    }

                    string valueValid = GenerateAFM.GenerateValid(repeatTolerance: repeatTolerance);
                    bool validValid = ValidateAFM.Validate(valueValid);
                    string bodyValid = valueValid.Substring(0, 8);
                    Assert.IsTrue(validValid, string.Format(Messages.MessageNotValidated, valueValid));

                    var reMatchesValid = re.Matches(bodyValid);
                    if (repeatTolerance == 0)
                    {
                        Assert.AreEqual(0, reMatchesValid.Count,
                            string.Format(Messages.MessageRepeatToleranceNotExpected, repeatTolerance, reMatchesValid.Count, bodyValid));
                    }
                    else
                    {
                        foreach (Match repeat in reMatchesValid)
                        {
                            Assert.IsTrue(repeat.Value.Length <= (repeatTolerance + 1),
                                string.Format(Messages.MessageRepeatToleranceRepeatExceeded, repeatTolerance, repeat.Value.Length, repeat.Value, bodyValid));
                        }
                    }

                    string valueInvalid = GenerateAFM.GenerateInvalid(repeatTolerance: repeatTolerance);
                    bool invalidInvalid = ValidateAFM.Validate(valueInvalid);
                    string bodyInvalid = valueInvalid.Substring(0, 8);
                    Assert.IsFalse(invalidInvalid, string.Format(Messages.MessageNotInvalidated, valueInvalid));

                    var reMatchesInvalid = re.Matches(bodyInvalid);
                    if (repeatTolerance == 0)
                    {
                        Assert.AreEqual(0, reMatchesInvalid.Count,
                            string.Format(Messages.MessageRepeatToleranceNotExpected, repeatTolerance, reMatchesInvalid.Count, bodyInvalid));
                    }
                    else
                    {
                        foreach (Match repeat in reMatchesInvalid)
                        {
                            Assert.IsTrue(repeat.Value.Length <= (repeatTolerance + 1),
                                string.Format(Messages.MessageRepeatToleranceRepeatExceeded, repeatTolerance, repeat.Value.Length, repeat.Value, bodyInvalid));
                        }
                    }
                }
            }
        }
    }
}
