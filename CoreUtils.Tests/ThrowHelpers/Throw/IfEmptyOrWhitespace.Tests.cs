namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Throw_IfEmptyOrWhitespace_Tests
    {
        [Test]
        public void Throw_IfEmptyOrWhitespace_Ok()
        {
            Assert.DoesNotThrow(() => Throw.IfEmptyOrWhitespace("helloWorld", "testString"));
        }

        [Test]
        public void Throw_IfEmptyOrWhitespace_NullIsAllowed()
        {
            Assert.DoesNotThrow(() => Throw.IfEmptyOrWhitespace(null, "testString"));
        }

        [Test]
        public void Throw_IfEmptyOrWhitespace_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfEmptyOrWhitespace(string.Empty, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be empty"));
        }

        [Test]
        public void Throw_IfEmptyOrWhitespace_Whitespace()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfEmptyOrWhitespace(" ", "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be whitespace"));
        }
    }
}
