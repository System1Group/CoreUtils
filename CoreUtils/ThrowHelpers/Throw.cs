namespace System1Group.Lib.CoreUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Throw
    {
        public static void IfNull(object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void IfNullOrEmpty(string value, string paramName)
        {
            IfNull(value, paramName);

            IfEmpty(value, paramName);
        }

        public static void IfNullEmptyOrWhitespace(string value, string paramName)
        {
            IfNullOrEmpty(value, paramName);

            IfWhitespace(value, paramName);
        }

        public static void IfNullOrEmpty<T>(IEnumerable<T> value, string paramName)
        {
            IfNull(value, paramName);

            if (!value.Any())
            {
                throw new ArgumentException("Collection should not be empty", paramName);
            }
        }

        public static void IfEmptyOrWhitespace(string value, string paramName)
        {
            if (value == null)
            {
                return;
            }

            IfEmpty(value, paramName);

            IfWhitespace(value, paramName);
        }

        public static void IfWhitespace(string value, string paramName)
        {
            if (value == null)
            {
                return;
            }

            if (string.CompareOrdinal(value.Trim(), string.Empty) == 0)
            {
                throw new ArgumentException("Value should not be whitespace", paramName);
            }
        }

        private static void IfEmpty(string value, string paramName)
        {
            if (string.CompareOrdinal(value, string.Empty) == 0)
            {
                throw new ArgumentException("Value should not be empty", paramName);
            }
        }
    }
}
