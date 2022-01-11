using System;

namespace GlobalStrings.Exeptions
{
    public class IsNotJsonFileException : Exception
    {
        private const string EXCEPTION_MESSAGE = "The file {0} is not a JSON file.";

        public IsNotJsonFileException(string filepath) : base(string.Format(EXCEPTION_MESSAGE, filepath))
        { /*Not implementation*/ }
    }
}