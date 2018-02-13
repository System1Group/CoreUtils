namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    public class Throw_OrThrowIfInfinityOrNaN_Tests
    {
        [Test]
        public void Ok_Zero()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfInfinityOrNaN(0.0, "testString"));
            Assert.AreEqual(0.0, ReturnParameter.OrThrowIfInfinityOrNaN(0.0, "testString"));
        }

        [Test]
        public void Ok_Positive()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfInfinityOrNaN(1.3, "testString"));
            Assert.AreEqual(1.3, ReturnParameter.OrThrowIfInfinityOrNaN(1.3, "testString"));
        }

        [Test]
        public void Ok_Negative()
        {
            Assert.DoesNotThrow(() => ReturnParameter.OrThrowIfInfinityOrNaN(-1.3, "testString"));
            Assert.AreEqual(-1.3, ReturnParameter.OrThrowIfInfinityOrNaN(-1.3, "testString"));
        }

        [Test]
        public void ThrowForPositiveInfinity()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfInfinityOrNaN(double.PositiveInfinity, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be infinity"));
        }

        [Test]
        public void ThrowForNegativeInfinity()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfInfinityOrNaN(double.NegativeInfinity, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be infinity"));
        }

        [Test]
        public void ThrowForNaN()
        {
            var x = Assert.Throws<ArgumentException>(() => ReturnParameter.OrThrowIfInfinityOrNaN(double.NaN, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be NaN"));
        }
    }
}
