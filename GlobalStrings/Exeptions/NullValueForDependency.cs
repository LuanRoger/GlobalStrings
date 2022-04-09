using System;

namespace GlobalStrings.Exeptions
{
    public class NullValueForDependency : Exception
    {
        private const string MESSAGE = "The value {0} is true, but {1} is null";

        public NullValueForDependency(string value, string nullValue) : 
            base(string.Format(MESSAGE, value, nullValue)) {/*Nothing*/}
    }
}