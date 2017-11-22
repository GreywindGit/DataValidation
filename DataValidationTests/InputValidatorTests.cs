using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataValidation;

namespace DataValidationTests
{
    [TestClass]
    public class InputValidatorTests
    {
        InputValidator validator = new InputValidator();

        #region Tests for name validation
        [TestMethod]
        public void ValidName_NoName_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidName("");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidName_AllLowercaseName_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidName("sun flower");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidName_NonAlphabeticCharacters_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidName("Sun Flower1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidName_AllUppercaseName_ReturnsTrue()
        {
            bool expected = true;
            bool actual = validator.ValidName("SUN FLOWER");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidName_MixedCaseName_ReturnsTrue()
        {
            bool expected = true;
            bool actual = validator.ValidName("SunFlower");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidName_NameWithAccentedCharacters_ReturnsTrue()
        {
            bool expected = true;
            bool actual = validator.ValidName("Őrségi Űrviselt Úrinő");
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Tests for phone number validation
        [TestMethod]
        public void ValidPhone_NoPhoneNumber_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidPhone("");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhone_PhoneNumberWithNotAllowedChars_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidPhone("+36-20-123-a234");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhone_NotHungarianCountryCode_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidPhone("+37-1-200-3000");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhone_InvalidAreaCode_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidPhone("+36-40-111-1111");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhone_InvalidPhoneNumberLength_ReturnsFalse()
        {
            bool expected = false;
            bool actual = validator.ValidPhone("+36-22-111-1111");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhone_PhoneNumberUndividedFormat_ReturnsTrue()
        {
            bool expected = true;
            bool actual = validator.ValidPhone("+36-20-4172112");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidPhone_PhoneNumberDividedFormat_ReturnsTrue()
        {
            bool expected = true;
            bool actual = validator.ValidPhone("+36-20-417-2112");
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
