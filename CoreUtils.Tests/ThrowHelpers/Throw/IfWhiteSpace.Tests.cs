namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Throw_IfWhiteSpace_Tests
    {
        [Test]
        public void Throw_IfWhitespace_Ok()
        {
            Assert.DoesNotThrow(() => Throw.IfWhitespace("hello", "TestParam"));
        }

        [Test]
        public void Throw_IfNull_Null()
        {
            Assert.DoesNotThrow(() => Throw.IfWhitespace(null, "TestParam"));
        }

        [Test]
        public void Throw_IfNull_Ok_WhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => Throw.IfWhitespace(" ", "testParam"));
        }
    }
}
