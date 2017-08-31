namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ReturnParameter_OrThrowIfWhiteSpace_Tests
    {
        [Test]
        public void ReturnParameter_OrThrowIfWhiteSpace_Ok()
        {
            const string valueToTest = "Hello";
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfWhitespace(valueToTest, "test"));
            Assert.AreEqual(ReturnParameter.OrThrowIfWhitespace(valueToTest, "test"), valueToTest);
        }

        [Test]
        public void ReturnParameter_OrThrowIfWhiteSpace_Ok_Null()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfWhitespace((string)null, "test"));
        }

        [Test]
        public void ReturnParameter_OrThrowIfWhiteSpace_WhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfWhitespace(" ", "test"));
        }
    }
}
