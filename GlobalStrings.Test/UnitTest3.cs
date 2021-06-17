using System;
using Xunit;
using System.Collections.Generic;

namespace GlobalStrings.Test
{
    public class UnitTest3
    {
        private Globalization globalization;
        private Globalization<string, int> globalizationGeneric;

        private string congrats;
        private string wellcome;

        [Fact]
        public void SetTextWithGlobal()
        {
            GlobalIntanceOfGlobalization();
            
            Assert.Equal("Olá", congrats);
        }
        [Fact]
        public void CloneAndSetText()
        {
            GlobalIntanceOfGlobalization();

            globalization = (Globalization)Globalization.GetGlobalizaztionInstance().Clone();
            globalization.LangTextObserver += (_, _) =>
            {
                wellcome = globalization.SetText(1);
            };
            globalization.SyncStrings();

            Assert.Equal("Seja Bem-Vindo", wellcome);
        }
        [Fact]
        public void SetTextWithGlobalGeneric()
        {
            GlobalIntanceOfGlobalizationGeneric();

            Assert.Equal("Olá", congrats);
        }
        [Fact]
        public void CloneGenericAndSetText()
        {
            GlobalIntanceOfGlobalizationGeneric();

            globalizationGeneric = (Globalization<string, int>)Globalization<string, int>
                .GetGlobalizaztionInstance().Clone();
            globalizationGeneric.LangTextObserver += (_, _) =>
            {
                wellcome = globalizationGeneric.SetText(1);
            };
            globalizationGeneric.SyncStrings();

            Assert.Equal("Seja Bem-Vindo", wellcome);
        }
        [Fact]
        public void ChangeLangWithClone()
        {
            GlobalIntanceOfGlobalization();

            globalization = (Globalization)Globalization.GetGlobalizaztionInstance().Clone();
            globalization.LangTextObserver += (_, _) =>
            {
                congrats = globalization.SetText(0);
            };
            globalization.SyncStrings();

            Assert.Equal("Olá", congrats);

            globalization.UpdateLang(1);

            Assert.Equal("Hello", congrats);
        }

        [Fact]
        public void GlobalIntanceOfGlobalization()
        {
            LanguageInfo languagePtBr = new(0);
            languagePtBr.textLangBook = new();
            languagePtBr.textLangBook.Add(0, "Olá");
            languagePtBr.textLangBook.Add(1, "Seja Bem-Vindo");

            LanguageInfo languageEn = new(1, new Dictionary<int, string> {
                { 0, "Hello" },
                { 1, "Wellcome" }
            });

            List<LanguageInfo> languageInfos = new(){languagePtBr, languageEn};

            Globalization.SetGlobalizationInstance(new Globalization(languageInfos, 0));
            Globalization.GetGlobalizaztionInstance().LangTextObserver += UnitTest3_LangTextObserver;
            Globalization.GetGlobalizaztionInstance().StartGlobalization();
        }
        [Fact]
        public void GlobalIntanceOfGlobalizationGeneric()
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

            Globalization<string, int>.SetGlobalizationInstance(new Globalization<string, int>(languageInfos, "pt_br"));
            Globalization<string, int>.GetGlobalizaztionInstance().LangTextObserver += UnitTest3_LangTextObserverGeneric;
            Globalization<string, int>.GetGlobalizaztionInstance().StartGlobalization();
        }

        private void UnitTest3_LangTextObserverGeneric(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = Globalization<string, int>.GetGlobalizaztionInstance().SetText(0);
        }

        private void UnitTest3_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = Globalization.GetGlobalizaztionInstance().SetText(0);
        }
    }
}
