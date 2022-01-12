using System.Diagnostics.CodeAnalysis;

namespace GlobalStrings.Types
{
    /// <summary>
    /// Contains language information.
    /// </summary>
    /// <typeparam name="TLangCode">Defines the type used to identify <c>LanguageInfo&lt;TLangCode, KTextCode&gt;</c>.</typeparam>
    /// <typeparam name="GCollectionCode">Defines the type used to identify <c>TextBookCollection</c> collections.</typeparam>
    /// <typeparam name="KTextCode">Defines the type used to identify the strings in <c>LanguageInfo&lt;...&gt;.textBook</c>.</typeparam>
    public sealed class LanguageInfo<TLangCode, GCollectionCode, KTextCode>
    {
        /// <summary>
        /// Identifies the language by a unique code for each one.
        /// </summary>
        [NotNull]
        public TLangCode langCode { get; }
        
        /// <summary>
        /// Contains language strings collections.
        /// </summary>
        public TextBookCollection<GCollectionCode, KTextCode> textBookCollection { get; }

        /// <summary>
        /// Instantiate a new LanguageInfo.
        /// </summary>
        /// <param name="langCode">It is mandatory at first, define the code that will identify the language.</param>
        /// <param name="textBookCollection">Defines all collections used in the language.</param>
        public LanguageInfo([NotNull] TLangCode langCode, TextBookCollection<GCollectionCode, KTextCode> textBookCollection = null)
        {
            this.langCode = langCode;
            this.textBookCollection = textBookCollection;
        }
    }
}
