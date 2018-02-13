namespace System1Group.Lib.CoreUtils.Tests
{
    using System;
    using NUnit.Framework;

    public class Throw_IfInfinityOrNaN_Tests
    {
        [Test]
        public void Ok_Zero()
        {
            Assert.DoesNotThrow(() => Throw.IfInfinityOrNaN(0.0, "testString"));
        }

        [Test]
        public void Ok_Positive()
        {
            Assert.DoesNotThrow(() => Throw.IfInfinityOrNaN(1.3, "testString"));
        }

        [Test]
        public void Ok_Negative()
        {
            Assert.DoesNotThrow(() => Throw.IfInfinityOrNaN(-1.3, "testString"));
        }

        [Test]
        public void ThrowForPositiveInfinity()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfInfinityOrNaN(double.PositiveInfinity, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be infinity"));
        }

        [Test]
        public void ThrowForNegativeInfinity()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfInfinityOrNaN(double.NegativeInfinity, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be infinity"));
        }

        [Test]
        public void ThrowForNaN()
        {
            var x = Assert.Throws<ArgumentException>(() => Throw.IfInfinityOrNaN(double.NaN, "testString"));
            Assert.That(x.Message, Does.StartWith("Value should not be NaN"));
        }
    }
}
