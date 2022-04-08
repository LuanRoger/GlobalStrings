using System;
using System.Runtime.CompilerServices;

namespace GlobalStrings.Exeptions
{
    public class IsNotStringByFileException : Exception
    {
        private const string MESSAGE = "Is not possible execute {0}," +
                                       " becouse the language strings is not save in a JSON file";

        public IsNotStringByFileException([CallerMemberName] string methodName = null) : 
            base(string.Format(MESSAGE, methodName)) { /*Nothing*/ }
    }
}