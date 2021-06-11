using System.Collections.Generic;
using Xunit;

namespace GlobalStrings.Test
{
    public class UnitTest1
    {
        Globalization<string, int> globalization;

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

            globalization.UpdateLang("en");

            Assert.Equal("Hello", congrats);
        }

        [Fact]
        public void ChangeMoreStringsTest()
        {
            StartGlobalization();
            Assert.Equal("Olá", congrats);
            Assert.Equal("Seja Bem-Vindo", wellcome);

            globalization.UpdateLang("en");

            Assert.Equal("Hello", congrats);
            Assert.Equal("Wellcome", wellcome);
        }

        private void StartGlobalization()
        {
            LanguageInfo<string, int> languagePtBr = new("pt_br");
            languagePtBr.textLangBook = new();
            languagePtBr.textLangBook.Add(0, "Olá");
            languagePtBr.textLangBook.Add(1, "Seja Bem-Vindo");

            LanguageInfo<string, int> languageEn = new("en", new Dictionary<int, string>() {
                { 0, "Hello" },
                { 1, "Wellcome" }
            });

            List<LanguageInfo<string, int>> languageInfos = new(){languagePtBr, languageEn};

            globalization = new(languageInfos, "pt_br");
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
