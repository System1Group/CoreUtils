namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ReturnParameter_OrThrowIfNullOrEmpty_String_Tests
    {
        [Test]
        public void ReturnParameter_OrThrowIfNullOrEmpty_Ok()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfNullOrEmpty("helloWorld", "testString"));
            Assert.AreEqual(ReturnParameter.OrThrowIfNullOrEmpty("helloWorld", "testString"), "helloWorld");
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullOrEmpty_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ReturnParameter.OrThrowIfNullOrEmpty(null, "testString"));
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullOrEmpty_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfNullOrEmpty(string.Empty, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be empty"));
        }
    }
}
