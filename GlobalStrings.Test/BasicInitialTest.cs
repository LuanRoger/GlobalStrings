using System.Collections.Generic;
using GlobalStrings.EventArguments;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using Xunit;

namespace GlobalStrings.Test
{
    public class BasicInitialTest
    {
        private Globalization<string, string, int> _globalization { get; set; }
        private string congrats;
        private string wellcome;

        public BasicInitialTest()
        {
            StartGlobalization();
        }
        private void StartGlobalization()
        {
            LanguageInfo<string, string, int> languageInfoEnUs = new("en_us", new(new()
            {
                {"Home", new()
                {
                    { 0, "Hello" }, 
                    { 1, "Wellcome" }  
                }}
            }));
            LanguageInfo<string, string, int> languageInfoPtBr = new("pt_br", new(new()
            {
                { "Home", new()
                {
                    {0, "Olá"},
                    {1, "Seja Bem-Vindo"}
                }}
            }));
            List<LanguageInfo<string, string, int>> languageInfos = new() { languageInfoEnUs, languageInfoPtBr };

            _globalization = new(languageInfos, "pt_br");
            _globalization.LangTextObserver += Globalization_LangTextObserver;
            _globalization.StartGlobalization();
        }

        [Fact]
        public void LinguageInitialTest()
        {
            Assert.Equal("Olá", congrats);
        }

        [Fact]
        public void ChangeLanguageTest()
        {
            _globalization.UpdateLang("en_us");

            Assert.Equal("Hello", congrats);
        }

        [Fact]
        public void ChangeMoreStringsTest()
        {
            Assert.Equal("Olá", congrats);
            Assert.Equal("Seja Bem-Vindo", wellcome);

            _globalization.UpdateLang("en_us");

            Assert.Equal("Hello", congrats);
            Assert.Equal("Wellcome", wellcome);
        }
        
        [Fact]
        public void SyncStringsTest()
        {
            _globalization.SyncStrings();
        }
        
        private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = _globalization.SetText("Home", 0);
            wellcome = _globalization.SetText(new("Home", 1));
        }
    }
}
