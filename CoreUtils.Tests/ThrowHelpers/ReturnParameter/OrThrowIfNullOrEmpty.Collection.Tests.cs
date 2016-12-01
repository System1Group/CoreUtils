namespace BJ.Core.Tests
{
    using System;
    using System.Collections.Generic;

    using CoreUtils;

    using NUnit.Framework;

    [TestFixture]
    public class ReturnParameter_OrThrowIfNullOrEmpty_Collection_Tests
    {
        [Test]
        public void ReturnParameter_OrThrowIfNullOrEmpty_Collection_Ok()
        {
            var testColl = new List<int> { 1, 2, 3 };
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfNullOrEmpty(testColl, "list"));
            Assert.That(ReturnParameter.OrThrowIfNullOrEmpty(testColl, "list"), Is.EqualTo(testColl));
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullOrEmpty_Collection_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ReturnParameter.OrThrowIfNullOrEmpty(null, "list"));
        }

        [Test]
        public void ReturnParameter_OrThrowIfNullOrEmpty_Collection_Empty()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfNullOrEmpty(new List<int>(), "list"));
            Assert.That(x.Message, Does.StartWith("Collection should not be empty"));
        }
    }
}
