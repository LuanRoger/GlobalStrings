using System.Collections.Generic;
using GlobalStrings.EventArguments;
using GlobalStrings.Globalization;
using Xunit;

namespace GlobalStrings.Test
{
    public class BasicInitialTest
    {
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

            Globalization<string, string, int>.GetGlobalizationInstance().UpdateLang("en");

            Assert.Equal("Hello", congrats);
        }

        [Fact]
        public void ChangeMoreStringsTest()
        {
            StartGlobalization();
            Assert.Equal("Olá", congrats);
            Assert.Equal("Seja Bem-Vindo", wellcome);

            Globalization<string, string, int>.GetGlobalizationInstance().UpdateLang("en");

            Assert.Equal("Hello", congrats);
            Assert.Equal("Wellcome", wellcome);
        }

        private void StartGlobalization()
        {
            LanguageInfo<string, string, int> languagePtBr = new("pt_br");
            languagePtBr.textBookCollection = new();
            languagePtBr.textBookCollection.Add("Home", new()
            {
                {0, "Olá"},
                {1, "Seja Bem-Vindo"}
            });

            LanguageInfo<string, string, int> languageEn = new("en", new()
            {
                {"Home", new()
                {
                    { 0, "Hello" },
                    { 1, "Wellcome" }
                }}
            });

            List<LanguageInfo<string, string, int>> languageInfos = new(){ languagePtBr, languageEn };;

            Globalization<string, string, int>.SetGlobalizationInstance(new(languageInfos, "pt_br"));
            Globalization<string, string, int>.GetGlobalizationInstance().LangTextObserver += Globalization_LangTextObserver;

            Globalization<string, string, int>.GetGlobalizationInstance().StartGlobalization();
        }

        private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = Globalization<string, string, int>.GetGlobalizationInstance().SetText("Home", 0);
            wellcome = Globalization<string, string, int>.GetGlobalizationInstance().SetText("Home", 1);
        }
    }
}
