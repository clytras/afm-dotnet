using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lytrax.AFM;

namespace Lytrax.AFM.Tests
{
    [TestClass]
    public class TestValidation
    {
        private readonly string MessageNotValidated = "Validate does not validate valid number (number = {0})";
        private readonly string MessageClassInstanceNotEqualNumber = "ValidateAFM class instance Number not equal number (.Number = {0}, number = {1})";
        private readonly string MessageClassInstanceErrorShouldBe = "ValidateAFM class instance Error should be \"{0}\" (.Error = \"{1}\")";
        private readonly string MessageNotInvalidated = "Validate does not invalidate invalid number (number = {0})";

        [TestMethod]
        public void TestValidateValidAfmNumbers()
        {
            foreach(string afm in Helpers.StaticValidNumbers)
            {
                bool result = ValidateAFM.Validate(afm);
                Assert.IsTrue(result, string.Format(MessageNotValidated, afm));

                var validator = new ValidateAFM(afm);
                Assert.IsTrue(validator.Valid, 
                    string.Format(MessageNotValidated, afm));
                Assert.AreEqual(validator.Number, afm, 
                    string.Format(MessageClassInstanceNotEqualNumber, validator.Number, afm));
                Assert.AreEqual(validator.Error, "", 
                    string.Format(MessageClassInstanceErrorShouldBe, "", validator.Error));
            }
        }

        [TestMethod]
        public void TestInvalidateInvalidAfmNumbers()
        {
            foreach (string afm in Helpers.StaticInvalidNumbers)
            {
                bool result = ValidateAFM.Validate(afm);
                Assert.IsFalse(result, string.Format(MessageNotInvalidated, afm));

                var validator = new ValidateAFM(afm);
                Assert.IsFalse(validator.Valid,
                    string.Format(MessageNotInvalidated, afm));
                Assert.AreEqual(validator.Error, "invalid",
                    string.Format(MessageClassInstanceErrorShouldBe, "invalid", validator.Error));
            }
        }

        [TestMethod]
        public void TestInvalidateLengthError()
        {
            string afm = Helpers.InvalidErrors["length"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "length",
                string.Format(MessageClassInstanceErrorShouldBe, "length", validator.Error));
        }

        [TestMethod]
        public void TestInvalidateNanError()
        {
            string afm = Helpers.InvalidErrors["nan"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "nan",
                string.Format(MessageClassInstanceErrorShouldBe, "nan", validator.Error));
        }

        [TestMethod]
        public void TestInvalidateZeroError()
        {
            string afm = Helpers.InvalidErrors["zero"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "zero",
                string.Format(MessageClassInstanceErrorShouldBe, "zero", validator.Error));
        }

        [TestMethod]
        public void TestInvalidateInvalidError()
        {
            string afm = Helpers.InvalidErrors["invalid"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "invalid",
                string.Format(MessageClassInstanceErrorShouldBe, "invalid", validator.Error));
        }
    }
}
