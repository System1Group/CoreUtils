namespace CoreUtils.Tests
{
    using System;
    using System.Collections.Generic;

    using CoreUtils;

    using NUnit.Framework;

    [TestFixture]
    public class Throw_IfNullOrEmpty_Collection_Tests
    {
        [Test]
        public void Throw_IfNullOrEmpty_ICollection_Ok()
        {
            Assert.DoesNotThrow(() => Throw.IfNullOrEmpty(new List<int> { 1, 2, 3 }, "list"));
        }

        [Test]
        public void Throw_IfNullOrEmpty_ICollection_Null()
        {
            Assert.Throws<ArgumentNullException>(() => Throw.IfNullOrEmpty(null, "list"));
        }

        [Test]
        public void Throw_IfNullOrEmpty_ICollection_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfNullOrEmpty(new List<int>(), "list"));
            Assert.That(x.Message, Does.StartWith("Collection should not be empty"));
        }
    }
}
