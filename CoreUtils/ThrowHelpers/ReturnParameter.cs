namespace System1Group.Lib.CoreUtils
{
    using System.Collections.Generic;

    public static class ReturnParameter
    {
        public static T OrThrowIfNull<T>(T obj, string paramName)
        {
            Throw.IfNull(obj, paramName);
            return obj;
        }

        public static string OrThrowIfNullOrEmpty(string value, string paramName)
        {
            Throw.IfNullOrEmpty(value, paramName);
            return value;
        }

        public static string OrThrowIfNullEmptyOrWhitespace(string value, string paramName)
        {
            Throw.IfNullEmptyOrWhitespace(value, paramName);
            return value;
        }

        public static ICollection<T> OrThrowIfNullOrEmpty<T>(ICollection<T> value, string paramName)
        {
            Throw.IfNullOrEmpty(value, paramName);
            return value;
        }

        public static string OrThrowIfEmptyOrWhitespace(string value, string paramName)
        {
            Throw.IfEmptyOrWhitespace(value, paramName);
            return value;
        }

        public static string OrThrowIfWhitespace(string value, string paramName)
        {
            Throw.IfWhitespace(value, paramName);
            return value;
        }
    }
}