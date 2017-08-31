namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Throw_IfNullEmptyOrWhitespace_Tests
    {
        [Test]
        public void Throw_IfNullEmptyOrWhitespace_Ok()
        {
            Assert.DoesNotThrow(() => Throw.IfNullEmptyOrWhitespace("helloWorld", "testString"));
        }

        [Test]
        public void Throw_IfNullEmptyOrWhitespace_Null()
        {
            Assert.Throws<ArgumentNullException>(() => Throw.IfNullEmptyOrWhitespace(null, "testString"));
        }

        [Test]
        public void Throw_IfNullEmptyOrWhitespace_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfNullEmptyOrWhitespace(string.Empty, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be empty"));
        }

        [Test]
        public void Throw_IfNullEmptyOrWhitespace_Whitespace()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfNullEmptyOrWhitespace(" ", "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be whitespace"));
        }
    }
}
