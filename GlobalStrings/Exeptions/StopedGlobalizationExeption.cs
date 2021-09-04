using System;

namespace GlobalStrings.Exeptions
{
    internal class StopedGlobalizationExeption : Exception
    {
        private const string STOPED_GLOBALIZATION_EXEPTION_MESSAGE = 
            "Globalization has not started. Call StartGlobalization first.";
        
        public StopedGlobalizationExeption() : base(STOPED_GLOBALIZATION_EXEPTION_MESSAGE) {}
    }
}
