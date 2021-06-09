using System;
using System.Collections.Generic;
using Xunit;

namespace GlobalStrings.Test
{
    public class UnitTestFail
    {
        Globalization globalization;

        private string congrats;
        private string wellcome;

        [Fact]
        public void StartGlobalizationSameLangCode()
        {
            LanguageInfo languagePtBr = new(0);
            languagePtBr.textLangBook = new();
            languagePtBr.textLangBook.Add(0, "Olá");
            languagePtBr.textLangBook.Add(1, "Seja Bem-Vindo");

            LanguageInfo languageEn = new(0);
            languageEn.textLangBook = new();
            languageEn.textLangBook.Add(0, "Hello");
            languageEn.textLangBook.Add(1, "Wellcome");

            List<LanguageInfo> languageInfos = new(){languagePtBr, languageEn};

            Assert.Throws<ArgumentException>(() => globalization = new(languageInfos, 0));
        }

        private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = globalization.SetText(0);
            wellcome = globalization.SetText(1);
        }
    }
}
