using System;

namespace BizVal.Framework
{
    public static class Contract
    {
        private const string ArgumentNullExceptionErrorPattern = "Argument with name {0} is null";
        private const string ArgumentExceptionErrorPattern = "Argument with name {0} is null or emtpy";

        public static T NotNull<T>(T argument, string argumentName) where T : class
        {
            if (argument != null)
            {
                return argument;
            }
            throw new ArgumentNullException(string.Format(ArgumentNullExceptionErrorPattern, argumentName));
        }

        public static string NotEmpty(string argument, string argumentName)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return argument;
            }
            throw new ArgumentNullException(string.Format(ArgumentExceptionErrorPattern, argumentName));
        }
    }
}
