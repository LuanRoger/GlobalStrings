using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GlobalStrings.Exeptions
{
    [Serializable]
    class StopedGlobalizationExeption : Exception
    {
        public StopedGlobalizationExeption() : base() {}
        public StopedGlobalizationExeption(string message) : base(message) {}
        public StopedGlobalizationExeption(string message, Exception inner) {}
        public StopedGlobalizationExeption(SerializationInfo sInfo, 
            StreamingContext streamingContext) : base(sInfo, streamingContext) {}
    }
}
