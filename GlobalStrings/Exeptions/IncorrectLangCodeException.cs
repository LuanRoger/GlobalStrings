using System;
using System.Reflection;

namespace GlobalStrings.Exeptions
{
    public class IncorrectLangCodeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "LangCode does not exist or has not been defined in the List";

        public IncorrectLangCodeException(MemberInfo objectList) : base(EXCEPTION_MESSAGE)
        {
            base.Source = objectList.Name;
        }
    }
}