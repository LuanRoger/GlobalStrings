using System.Collections.Generic;

namespace GlobalStrings
{
    public sealed class LanguageInfo<TLangCode, KTextCode>
    {
        public TLangCode langCode { get; private set;}
        public Dictionary<KTextCode, string> textLangBook { get; set;}

        public LanguageInfo(TLangCode langCode, Dictionary<KTextCode, string> textLangBook = null)
        {
            this.langCode = langCode;
            this.textLangBook = textLangBook;
        }
    }
    public sealed class LanguageInfo
    {
        public int langCode { get; private set;}
        public Dictionary<int, string> textLangBook { get; set;}

        public LanguageInfo(int langCode, Dictionary<int, string> textLangBook = null)
        {
            this.langCode = langCode;
            this.textLangBook = textLangBook;
        }
    }
}
