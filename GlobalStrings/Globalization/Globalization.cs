using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GlobalStrings.Exeptions;

namespace GlobalStrings
{
    /// <summary>
    /// Class that help with language string management. The types used in <c>LanguageInfo<TLangCode, KTextCode></c> must be the same here.
    /// </summary>
    /// <typeparam name="TLangCode">Defines the type used to identify <c>LanguageInfo<TLangCode, KTextCode></c>.</typeparam>
    /// <typeparam name="KTextCode">Defines the type used to identify the strings in <c>LanguageInfo<...>.textBook</c></typeparam>
    public partial class Globalization<TLangCode, KTextCode>
    {
        [NotNull]
        private TLangCode langCodeNow { get; set;}
        [NotNull]
        private List<LanguageInfo<TLangCode, KTextCode>> languagesInfo { get; }
        public bool hasStarted {get; private set;} = false;

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
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public string SetText(KTextCode key)
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            var langToApply = languagesInfo.First(l => Equals(l.langCode, langCodeNow));
            return langToApply.textLangBook[key];
        }

        /// <summary>
        /// Switch from one language to another and update all strings in <c>LangTextObserver</c>.
        /// </summary>
        /// <param name="newLangCode">The new language code</param>
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public void UpdateLang(TLangCode newLangCode)
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            langCodeNow = newLangCode;
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Update, lang = newLangCode});
        }

        /// <summary>
        /// Set all strings in LangTextObserverCall for the first time.
        /// </summary>
        public void StartGlobalization()
        {
            hasStarted = true;
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Insert, lang = langCodeNow});
        }

        /// <summary>
        /// Call <c>LangTextObserver</c> to synchronize all strings with current language.
        /// </summary>
        public void SyncStrings()
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Sync, lang = langCodeNow});
        }
    }

    /// <summary>
    /// Class that help with language string management.
    /// This class cannot be used with <c>LanguageInfo<...></c>
    /// </summary>
    public partial class Globalization
    {
        [NotNull]
        private int langCodeNow { get; set;}
        [NotNull]
        private List<LanguageInfo> languagesInfo { get; }
        public bool hasStarted {get; private set;} = false;


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

        /// <summary>
        /// Set the text according to the current language. Must be used in <c>LangTextObserver</c> event.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A string according to the current language</returns>
        /// <example>string text = globalization.SetText(0)</example>
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public string SetText(int key)
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            var langToApply = languagesInfo.First(l => Equals(l.langCode, langCodeNow));
            return langToApply.textLangBook[key];
        }

        /// <summary>
        /// Switch from one language to another and update all strings in <c>LangTextObserver</c>.
        /// </summary>
        /// <param name="newLangCode">The new language code</param>
        /// <exception cref="StopedGlobalizationExeption"></exception>
        public void UpdateLang(int newLangCode)
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            langCodeNow = newLangCode;
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Update, lang = newLangCode});
        }

        /// <summary>
        /// Set all strings in LangTextObserverCall for the first time.
        /// </summary>
        public void StartGlobalization()
        {
            hasStarted = true;
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Insert, lang = langCodeNow});
        }

        /// <summary>
        /// Call <c>LangTextObserver</c> to synchronize all strings with current language.
        /// </summary>
        public void SyncStrings()
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            LangTextObserverCall(this, new UpdateModeEventArgs {mode = UpdateMode.Sync, lang = langCodeNow});
        }
    }
}
