namespace CoreUtils.Tests
{
    using System;

    using CoreUtils;

    using NUnit.Framework;

    [TestFixture]
    public class ReturnParameter_OrThrowIfNullEmptyOrWhitespace_Tests
    {
        [Test]
        public void ReturnParameter_OrThrowIfNullEmptyOrWhitespace_Ok()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfNullEmptyOrWhitespace("helloWorld", "testString"));
            Assert.AreEqual(ReturnParameter.OrThrowIfNullEmptyOrWhitespace("helloWorld", "testString"), "helloWorld");
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullEmptyOrWhitespace_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ReturnParameter.OrThrowIfNullEmptyOrWhitespace(null, "testString"));
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullEmptyOrWhitespace_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfNullEmptyOrWhitespace(string.Empty, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be empty"));
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullEmptyOrWhitespace_Whitespace()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfNullEmptyOrWhitespace(" ", "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be whitespace"));
        }
    }
}
