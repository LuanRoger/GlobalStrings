namespace GlobalStrings.Globalization
{
    public partial class Globalization<TLangCode, GCollectionCode, KTextCode>
    {
        private static Globalization<TLangCode, GCollectionCode, KTextCode> globalizationInstance {get; set;}

        /// <summary>
        /// Get the global instance of <c>Globalization</c>
        /// </summary>
        /// <returns><c>Globalization</c> instance</returns>
        public static Globalization<TLangCode, GCollectionCode, KTextCode> GetGlobalizationInstance() => globalizationInstance;

        /// <summary>
        /// Set the global instance of <c>Globalization</c>
        /// </summary>
        /// <param name="globalization">New value for <c>Globalization</c> global instance</param>
        public static void SetGlobalizationInstance(Globalization<TLangCode, GCollectionCode, KTextCode> globalization) => 
            globalizationInstance = globalization;

        /// <summary>
        /// Creates a shallow copy of the current System.Object.
        /// </summary>
        /// <returns>A shallow copy of the current System.Object.</returns>
        public object Clone() => MemberwiseClone();

        /// <summary>
        /// Return <c>globalizationInstance</c> to null.
        /// </summary>
        public void Clear() => globalizationInstance = null;
    }
}
