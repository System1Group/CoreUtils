namespace System1Group.Lib.CoreUtils
{
    using System;

    public static class LazyValue
    {
        public static LazyValue<T> Create<T>(Func<T> factory)
        {
            return new LazyValue<T>(factory);
        }
    }
}