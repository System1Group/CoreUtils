namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Throw_IfNull_Tests
    {
        [Test]
        public void Throw_IfNull_Ok()
        {
            Assert.DoesNotThrow(() => Throw.IfNull(new object(), "TestParam"));
        }

        [Test]
        public void Throw_IfNull_Null()
        {
            Assert.Throws<ArgumentNullException>(() => Throw.IfNull(null, "testParam"));
        }
    }
}
