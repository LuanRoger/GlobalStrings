using System.Collections.Generic;
using Xunit;

namespace GlobalStrings.Test
{
    public class UnitTest2
    {
        Globalization<int, int, int> globalization;

        private string congrats;
        private string exit;
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
            LanguageInfo<int, int, int> languagePtBr = new(0);
            languagePtBr.textBookCollection = new();
            languagePtBr.textBookCollection.Add(0, new Dictionary<int, string>());
            languagePtBr.textBookCollection.Add(1, new Dictionary<int, string>());
            languagePtBr.textBookCollection[0].Add(0, "Olá");
            languagePtBr.textBookCollection[1].Add(0, "Seja Bem-Vindo");
            languagePtBr.textBookCollection[1].Add(1, "Sair");

            LanguageInfo<int, int, int> languageEn = new(1);
            languageEn.textBookCollection = new();
            languageEn.textBookCollection.Add(0, new Dictionary<int, string>());
            languageEn.textBookCollection.Add(1, new Dictionary<int, string>());
            languageEn.textBookCollection[0].Add(0, "Hello");
            languageEn.textBookCollection[1].Add(0, "Wellcome");
            languageEn.textBookCollection[1].Add(1, "Exit");

            List<LanguageInfo<int, int, int>> languageInfos = new(){languagePtBr, languageEn};

            globalization = new(languageInfos, 0);
            globalization.LangTextObserver += Globalization_LangTextObserver;

            globalization.StartGlobalization();
        }

        private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = globalization.SetText(0, 0);
            wellcome = globalization.SetText(1, 0);
            exit = globalization.SetText(1, 1);
        }
    }
}
