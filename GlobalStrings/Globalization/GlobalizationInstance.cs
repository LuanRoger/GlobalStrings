using System;

namespace GlobalStrings
{
    public partial class Globalization<TLangCode, KTextCode>
    {
        private static Globalization<TLangCode, KTextCode> globalizationInstance {get; set;}

        /// <summary>
        /// Get the global instance of <c>Globalization</c>
        /// </summary>
        /// <returns><c>Globalization</c> instance</returns>
        public static Globalization<TLangCode, KTextCode> GetGlobalizaztionInstance() => globalizationInstance;

        /// <summary>
        /// Set the global instance of <c>Globalization</c>
        /// </summary>
        /// <param name="globalization">New value for <c>Globalization</c> global instance</param>
        public static void SetGlobalizationInstance(Globalization<TLangCode, KTextCode> globalization) => 
            globalizationInstance = globalization;

        /// <summary>
        /// Creates a shallow copy of the current System.Object.
        /// </summary>
        /// <returns>A shallow copy of the current System.Object.</returns>
        public object Clone() => MemberwiseClone();
    }
    public partial class Globalization : ICloneable
    {
        private static Globalization globalizationInstance {get; set;}

        /// <summary>
        /// Get the global instance of <c>Globalization</c>
        /// </summary>
        /// <returns><c>Globalization</c> instance</returns>
        public static Globalization GetGlobalizaztionInstance() => globalizationInstance;

        /// <summary>
        /// Set the global instance of <c>Globalization</c>
        /// </summary>
        /// <param name="globalization">New value for <c>Globalization</c> global instance</param>
        public static void SetGlobalizationInstance(Globalization globalization) => globalizationInstance = globalization;

        /// <summary>
        /// Creates a shallow copy of the current System.Object.
        /// </summary>
        /// <returns>A shallow copy of the current System.Object.</returns>
        public object Clone() => MemberwiseClone();
    }
}
