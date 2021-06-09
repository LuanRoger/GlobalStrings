using System.Collections.Generic;
using Xunit;

namespace GlobalStrings.Test
{
    public class UnitTest2
    {
        Globalization globalization;

        private string congrats;
        private string wellcome;

        [Fact]
        public void LinguageInitialTest()
        {
            StartGlobalization();

            Assert.Equal("Olá", congrats);
        }

        [Fact]
        public void ChangeLanguageTest()
        {
            StartGlobalization();

            globalization.UpdateLang(1);

            Assert.Equal("Hello", congrats);
        }

        [Fact]
        public void ChangeMoreStringsTest()
        {
            StartGlobalization();
            Assert.Equal("Olá", congrats);
            Assert.Equal("Seja Bem-Vindo", wellcome);

            globalization.UpdateLang(1);

            Assert.Equal("Hello", congrats);
            Assert.Equal("Wellcome", wellcome);
        }

        [Fact]
        public void StartGlobalization()
        {
            LanguageInfo languagePtBr = new(0);
            languagePtBr.textLangBook = new();
            languagePtBr.textLangBook.Add(0, "Olá");
            languagePtBr.textLangBook.Add(1, "Seja Bem-Vindo");

            LanguageInfo languageEn = new(1);
            languageEn.textLangBook = new();
            languageEn.textLangBook.Add(0, "Hello");
            languageEn.textLangBook.Add(1, "Wellcome");

            List<LanguageInfo> languageInfos = new(){languagePtBr, languageEn};

            globalization = new(languageInfos, 0);
            globalization.LangTextObserver += Globalization_LangTextObserver;

            globalization.StartGlobalization();
        }

        private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = globalization.SetText(0);
            wellcome = globalization.SetText(1);
        }
    }
}
