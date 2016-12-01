namespace BJ.Core.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class LazyValue_Ok_Tests
    {
        [Test]
        public void Ok()
        {
            var calls = 0;

            Func<int> factory = () =>
                {
                    calls += 1;
                    return calls;
                };

            var lazy = LazyValue.Create(factory);

            // Value is lazy, so function hasn't been run yet
            Assert.AreEqual(calls, 0);

            // Getting the value once runs the function once
            Assert.AreEqual(lazy.Value, 1);
            Assert.AreEqual(calls, 1);

            // Getting the value again doesn't re-run the function; the result is cached.
            Assert.AreEqual(lazy.Value, 1);
            Assert.AreEqual(calls, 1);
        }
    }
}
