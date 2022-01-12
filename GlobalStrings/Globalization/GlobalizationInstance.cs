using System.Collections.Generic;
using GlobalStrings.Types;

namespace GlobalStrings.Globalization
{
    /// <summary>
    /// Manage the Globalization singleton (Global instance).
    /// </summary>
    /// <typeparam name="TLangCode">Defines the type used to identify <c>LanguageInfo&lt;TLangCode, KTextCode&gt;</c>.</typeparam>
    /// <typeparam name="GCollectionCode">Defines the type used to identify the strings in <c>LanguageInfo&lt;...&gt;.textBook</c>.</typeparam>
    /// <typeparam name="KTextCode">Defines the type used to identify <c>TextBookCollection</c> collections.</typeparam>
    public static class GlobalGlobalization<TLangCode, GCollectionCode, KTextCode>
    {
        private static Globalization<TLangCode, GCollectionCode, KTextCode> _globalGlobalization { get; set; }
        /// <summary>
        /// Initialize the global instance of Globalization if it's null on the <c>GetInstance</c>
        /// method call.
        /// </summary>
        public static bool autoInstanceIfNull { get; set; } = false;

        /// <summary>
        /// Get the global instance of <c>Globalization</c>
        /// </summary>
        /// <returns><c>Globalization</c> instance</returns>
        public static Globalization<TLangCode, GCollectionCode, KTextCode> GetInstance()
        {
            if(autoInstanceIfNull && _globalGlobalization == null)
                _globalGlobalization = new(new List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>>(), default);
            
            return _globalGlobalization;
        }

        /// <summary>
        /// Set the global instance of <c>Globalization</c>
        /// </summary>
        /// <param name="globalization">New value for <c>Globalization</c> global instance</param>
        public static void SetInstance(Globalization<TLangCode, GCollectionCode, KTextCode> globalization) => 
            _globalGlobalization = globalization;
        
        /// <summary>
        /// Set <c>globalizationInstance</c> to null.
        /// </summary>
        public static void ClearGlobalInstance() => _globalGlobalization = null;
    }
}
