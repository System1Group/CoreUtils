namespace CoreUtils
{
    using System;

    public class LazyValue<T>
    {
        private Func<T> factory;

        private T value;

        public LazyValue(Func<T> factory)
        {
            this.factory = ReturnParameter.OrThrowIfNull(factory, "factory");
        }

        public T Value
        {
            get
            {
                if (this.factory != null)
                {
                    this.value = this.factory();
                    this.factory = null; // Zero factory since we don't need it anymore and it might be holding memory
                }

                return this.value;
            }
        }
    }
}
