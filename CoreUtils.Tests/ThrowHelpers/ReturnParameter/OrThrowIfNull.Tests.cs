namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ReturnParameter_OrThrowIfNull_Tests
    {
        [Test]
        public void ReturnParameter_OrThrowIfNull_Ok()
        {
            var obj = new object();
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfNull(obj, "test"));
            Assert.AreEqual(ReturnParameter.OrThrowIfNull(obj, "test"), obj);
        }

        [Test]
        public void ReturnParameter_OrThrowIfNull_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ReturnParameter.OrThrowIfNull((string)null, "test"));
        }
    }
}
