namespace CoreUtils.Tests
{
    using System;

    using CoreUtils;

    using NUnit.Framework;

    [TestFixture]
    public class Throw_IfNullOrEmpty_String_Tests
    {
        [Test]
        public void Throw_IfNullOrEmpty_Ok()
        {
            Assert.DoesNotThrow(() => Throw.IfNullOrEmpty("helloWorld", "testString"));
        }

        [Test]
        public void Throw_IfNullOrEmpty_Null()
        {
            Assert.Throws<ArgumentNullException>(() => Throw.IfNullOrEmpty(null, "testString"));
        }

        [Test]
        public void Throw_IfNullOrEmpty_Empty()
        {
            Assert.Throws<ArgumentException>(() => Throw.IfNullOrEmpty(string.Empty, "testString"));
        }
    }
}
