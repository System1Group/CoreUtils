namespace CoreUtils.Tests
{
    using System;

    using CoreUtils;

    using NUnit.Framework;

    [TestFixture]
    public class ReturnParameter_OrThrowIfEmptyOrWhitespace_Tests
    {
        [Test]
        public void ReturnParameter_OrThrowIfEmptyOrWhitespace_Ok()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfEmptyOrWhitespace("helloWorld", "testString"));
            Assert.AreEqual(ReturnParameter.OrThrowIfEmptyOrWhitespace("helloWorld", "testString"), "helloWorld");
        }

        [Test]
        public void ReturnParameter_OrThrowIfEmptyOrWhitespace_Null()
        {
            var result = ReturnParameter.OrThrowIfEmptyOrWhitespace(null, "testString");
            Assert.AreEqual(null, result);
        }

        [Test]
        public void ReturnParameter_OrThrowIfEmptyOrWhitespace_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfEmptyOrWhitespace(string.Empty, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be empty"));
        }

        [Test]
        public void ReturnParameter_OrThrowIfEmptyOrWhitespace_Whitespace()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfEmptyOrWhitespace(" ", "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be whitespace"));
        }
    }
}
