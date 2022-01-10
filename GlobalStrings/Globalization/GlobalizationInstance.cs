namespace GlobalStrings.Globalization
{
    public partial class Globalization<TLangCode, GCollectionCode, KTextCode>
    {
        private static Globalization<TLangCode, GCollectionCode, KTextCode> globalizationInstance { get; set; }

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
        /// Set <c>globalizationInstance</c> to null.
        /// </summary>
        public void Clear() => globalizationInstance = null;
    }
}
