using System;
using System.Collections.Generic;
using Xunit;

namespace GlobalStrings.Test
{
    public class UnitTestFail
    {
        Globalization<int, int, int> globalization;

        private string congrats;
        private string wellcome;

        [Fact]
        public void StartGlobalizationSameLangCode()
        {
            LanguageInfo<int, int, int> languagePtBr = new(0);
            languagePtBr.textBookCollection = new();
            languagePtBr.textBookCollection.Add(0, new Dictionary<int, string>());
            languagePtBr.textBookCollection.Add(1, new Dictionary<int, string>());
            languagePtBr.textBookCollection[0].Add(0, "Olá");
            languagePtBr.textBookCollection[1].Add(0, "Seja Bem-Vindo");
            languagePtBr.textBookCollection[1].Add(1, "Sair");

            LanguageInfo<int, int, int> languageEn = new(0);
            languageEn.textBookCollection = new();
            languageEn.textBookCollection.Add(0, new Dictionary<int, string>());
            languageEn.textBookCollection.Add(1, new Dictionary<int, string>());
            languageEn.textBookCollection[0].Add(0, "Hello");
            languageEn.textBookCollection[1].Add(0, "Wellcome");
            languageEn.textBookCollection[1].Add(1, "Exit");

            List<LanguageInfo<int, int, int>> languageInfos = new(){languagePtBr, languageEn};

            Assert.Throws<ArgumentException>(() => globalization = new(languageInfos, 0));
        }
    }
}
