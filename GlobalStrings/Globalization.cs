using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GlobalStrings
{
    /// <summary>
    /// Class that help with language string management. The types used in <c>LanguageInfo<TLangCode, KTextCode></c> must be the same here.
    /// </summary>
    /// <typeparam name="TLangCode">Defines the type used to identify <c>LanguageInfo<TLangCode, KTextCode></c>.</typeparam>
    /// <typeparam name="KTextCode">Defines the type used to identify the strings in <c>LanguageInfo<...>.textBook</c></typeparam>
    public class Globalization<TLangCode, KTextCode>
    {
        [NotNull]
        private TLangCode langCodeNow { get; set;}
        [NotNull]
        private List<LanguageInfo<TLangCode, KTextCode>> languagesInfo { get; }

        /// <summary>
        /// Instance a new <c>Globalization</c>
        /// </summary>
        /// <param name="languagesInfo">List of languages that will be used in the application</param>
        /// <param name="langCodeNow">Initial language code</param>
        /// <exception cref="ArgumentException"></exception>
        public Globalization(List<LanguageInfo<TLangCode, KTextCode>> languagesInfo, TLangCode langCodeNow)
        {
            if(languagesInfo.GroupBy(code => code.langCode).Where(code => code.Count() > 1)
                .Select(code => code.Key).ToList().Count >= 1)
            {
                throw new ArgumentException("There is one or more languages with the same code");
            }

            this.langCodeNow = langCodeNow;
            this.languagesInfo = languagesInfo;
        }

        /// <summary>
        /// Set the text according to the current language. Must be used in <c>LangTextObserver</c> event.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A string according to the current language</returns>
        /// <example>string text = globalization.SetText(0)</example>
        public string SetText(KTextCode key)
        {
            var langToApply = languagesInfo.First(l => Equals(l.langCode, langCodeNow));
            return langToApply.textLangBook[key];
        }

        /// <summary>
        /// Switch from one language to another and update all strings in <c>LangTextObserver</c>.
        /// </summary>
        /// <param name="newLangCode">The new language code</param>
        public void UpdateLang(TLangCode newLangCode)
        {
            langCodeNow = newLangCode;
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Update, lang = newLangCode});
        }

        /// <summary>
        /// Set all strings in LangTextObserverCall for the first time.
        /// </summary>
        public void StartGlobalization() => LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Insert, lang = langCodeNow});

        public delegate void LangTextObserverEventHandler(object sender, UpdateModeEventArgs updateModeEventArgs);
        public virtual event LangTextObserverEventHandler LangTextObserver;

        /// <summary>
        /// Groups all strings to respond to language changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="updateModeEventArgs">Provides properties about language changes at runtime</param>
        private void LangTextObserverCall(object sender, UpdateModeEventArgs updateModeEventArgs) => 
            LangTextObserver?.Invoke(sender, updateModeEventArgs);
    }

    /// <summary>
    /// Class that help with language string management.
    /// This class cannot be used with <c>LanguageInfo<...></c>
    /// </summary>
    public class Globalization
    {
        [NotNull]
        private int langCodeNow { get; set;}
        private List<LanguageInfo> languagesInfo { get; }


        /// <summary>
        /// Instance a new <c>Globalization</c>
        /// </summary>
        /// <param name="languagesInfo">List of languages that will be used in the application</param>
        /// <param name="langCodeNow">Initial language code</param>
        /// <exception cref="ArgumentException"></exception>
        public Globalization(List<LanguageInfo> languagesInfo, int langCodeNow)
        {
            if(languagesInfo.GroupBy(code => code.langCode).Where(code => code.Count() > 1)
                .Select(code => code.Key).ToList().Count >= 1)
            {
                throw new ArgumentException("There is one or more languages with the same code");
            }

            this.langCodeNow = langCodeNow;
            this.languagesInfo = languagesInfo;
        }

        public string SetText(int key)
        {
            var langToApply = languagesInfo.First(l => Equals(l.langCode, langCodeNow));
            return langToApply.textLangBook[key];
        }

        public void UpdateLang(int newLangCode)
        {
            langCodeNow = newLangCode;
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Update, lang = newLangCode});
        }

        public void StartGlobalization() => LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Insert, lang = langCodeNow});

        public delegate void LangTextObserverEventHandler(object sender, UpdateModeEventArgs updateModeEventArgs);
        public virtual event LangTextObserverEventHandler LangTextObserver;
        private void LangTextObserverCall(object sender, UpdateModeEventArgs updateModeEventArgs) => 
            LangTextObserver?.Invoke(sender, updateModeEventArgs);
    }
}
