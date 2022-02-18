using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GlobalStrings.Exeptions;
using GlobalStrings.Extensions;
using GlobalStrings.Types;
using GlobalStrings.Types.Enums;

namespace GlobalStrings.Globalization
{
    /// <summary>
    /// Class that help with language string management. The types used in <c>LanguageInfo&lt;TLangCode, KTextCode&gt;</c> must be the same here.
    /// </summary>
    /// <typeparam name="TLangCode">Defines the type used to identify <c>LanguageInfo&lt;TLangCode, KTextCode&gt;</c>.</typeparam>
    /// <typeparam name="KTextCode">Defines the type used to identify the strings in <c>LanguageInfo&lt;...&gt;.textBook</c>.</typeparam>
    /// <typeparam name="GCollectionCode">Defines the type used to identify <c>TextBookCollection</c> collections.</typeparam>
    public partial class Globalization<TLangCode, GCollectionCode, KTextCode>
    {
        [NotNull]
        private TLangCode langCodeNow { get; set; }
        [NotNull]
        internal List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>> languagesInfo { get; set; }
        /// <summary>
        /// Get the state of the <c>Globalization</c>
        /// </summary>
        public bool hasStarted {get; private set;} = false;

        /// <summary>
        /// Instance a new <c>Globalization</c>.
        /// </summary>
        /// <param name="languagesInfo">List of languages that will be used in the application</param>
        /// <param name="langCodeNow">Initial language code</param>
        public Globalization([NotNull] List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>> languagesInfo,
            [NotNull] TLangCode langCodeNow)
        {
            this.langCodeNow = langCodeNow;
            this.languagesInfo = languagesInfo;
        }
        /// <summary>
        /// Instance a new <c>Globalization</c> and load all the string in the JSON file.
        /// </summary>
        /// <param name="filepath">Path to JSON file than contains all the languages strings.</param>
        /// <param name="langCodeNow">Initial language code</param>
        public Globalization([NotNull] string filepath, [NotNull] TLangCode langCodeNow)
        {
            this.langCodeNow = langCodeNow;
            this.LoadLanguageInfos(filepath);
        }

        /// <summary>
        /// Set the text according to the current language. Must be used in <c>LangTextObserver</c> event.
        /// </summary>
        /// <param name="collectionCode">Address where the string is in a collection.</param>
        /// <param name="key">String allocation key in a collection.</param>
        /// <returns>A string according to the current language.</returns>
        /// <example><code>string text = globalization.SetText(0)</code></example>
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public string SetText(GCollectionCode collectionCode, KTextCode key)
        {
            if(!hasStarted)
                throw new StopedGlobalizationExeption();

            return languagesInfo.First(c => Equals(c.langCode, langCodeNow))
                .textBookCollection[collectionCode][key];
        }
        /// <summary>
        /// Set the text according to the current language. Must be used in <c>LangTextObserver</c> event.
        /// </summary>
        /// <param name="textCode">Key pair than identify the text. Where the <c>Key</c> is the <c>GCollectionCode</c> and
        /// <c>Value</c> is <c>KTextCode</c>.</param>
        /// <returns>A string according to the current language.</returns>
        /// <example><code>string text = globalization.SetText(new("Home", 0))</code></example>
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public string SetText(KeyValuePair<GCollectionCode, KTextCode> textCode)
        {
            if(!hasStarted)
                throw new StopedGlobalizationExeption();

            return languagesInfo.First(c => Equals(c.langCode, langCodeNow))
                .textBookCollection[textCode.Key][textCode.Value];
        }

        /// <summary>
        /// Switch from one language to another and update all strings in <c>LangTextObserver</c> event.
        /// </summary>
        /// <param name="newLangCode">The new language code</param>
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public void UpdateLang(TLangCode newLangCode)
        {
            if(!hasStarted)
                throw new StopedGlobalizationExeption();
            if(!languagesInfo.Any(langInfo => langInfo.langCode.Equals(newLangCode)))
                throw new IncorrectLangCodeException(languagesInfo.GetType());
            
            langCodeNow = newLangCode;
            LangTextObserverCall(this, new(){mode = UpdateMode.Update, lang = newLangCode});
        }

        /// <summary>
        /// Set all strings in LangTextObserverCall for the first time.
        /// </summary>
        public void StartGlobalization()
        {
            hasStarted = true;
            LangTextObserverCall(this, new(){ mode = UpdateMode.Insert, lang = langCodeNow });
        }

        /// <summary>
        /// Call <c>LangTextObserver</c> to synchronize all strings with current language.
        /// </summary>
        public void SyncStrings()
        {
            if(!hasStarted)
                throw new StopedGlobalizationExeption();
            
            LangTextObserverCall(this, new(){ mode = UpdateMode.Sync, lang = langCodeNow });
        }
    }
}
