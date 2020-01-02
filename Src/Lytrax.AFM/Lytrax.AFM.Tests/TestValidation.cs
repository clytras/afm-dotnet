using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lytrax.AFM;

namespace Lytrax.AFM.Tests
{
    [TestClass]
    public class TestValidation
    {
        [TestMethod]
        public void TestValidateValidAfmNumbers()
        {
            foreach(string afm in Helpers.StaticValidNumbers)
            {
                bool result = ValidateAFM.Validate(afm);
                Assert.IsTrue(result, string.Format(Messages.MessageNotValidated, afm));

                var validator = new ValidateAFM(afm);
                Assert.IsTrue(validator.Valid, 
                    string.Format(Messages.MessageNotValidated, afm));
                Assert.AreEqual(validator.Number, afm, 
                    string.Format(Messages.MessageClassInstanceNotEqualNumber, validator.Number, afm));
                Assert.AreEqual(validator.Error, "", 
                    string.Format(Messages.MessageClassInstanceErrorShouldBe, "", validator.Error));
            }
        }

        [TestMethod]
        public void TestInvalidateInvalidAfmNumbers()
        {
            foreach (string afm in Helpers.StaticInvalidNumbers)
            {
                bool result = ValidateAFM.Validate(afm);
                Assert.IsFalse(result, string.Format(Messages.MessageNotInvalidated, afm));

                var validator = new ValidateAFM(afm);
                Assert.IsFalse(validator.Valid,
                    string.Format(Messages.MessageNotInvalidated, afm));
                Assert.AreEqual(validator.Error, "invalid",
                    string.Format(Messages.MessageClassInstanceErrorShouldBe, "invalid", validator.Error));
            }
        }

        [TestMethod]
        public void TestInvalidateLengthError()
        {
            string afm = Helpers.InvalidErrors["length"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(Messages.MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(Messages.MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "length",
                string.Format(Messages.MessageClassInstanceErrorShouldBe, "length", validator.Error));
        }

        [TestMethod]
        public void TestInvalidateNanError()
        {
            string afm = Helpers.InvalidErrors["nan"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(Messages.MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(Messages.MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "nan",
                string.Format(Messages.MessageClassInstanceErrorShouldBe, "nan", validator.Error));
        }

        [TestMethod]
        public void TestInvalidateZeroError()
        {
            string afm = Helpers.InvalidErrors["zero"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(Messages.MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(Messages.MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "zero",
                string.Format(Messages.MessageClassInstanceErrorShouldBe, "zero", validator.Error));
        }

        [TestMethod]
        public void TestInvalidateInvalidError()
        {
            string afm = Helpers.InvalidErrors["invalid"];
            bool result = ValidateAFM.Validate(afm);
            Assert.IsFalse(result, string.Format(Messages.MessageNotInvalidated, afm));

            var validator = new ValidateAFM(afm);
            Assert.IsFalse(validator.Valid,
                string.Format(Messages.MessageNotInvalidated, afm));
            Assert.AreEqual(validator.Error, "invalid",
                string.Format(Messages.MessageClassInstanceErrorShouldBe, "invalid", validator.Error));
        }
    }
}
