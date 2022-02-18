using GlobalStrings.EventArguments;
using GlobalStrings.Globalization;
using GlobalStrings.Test.Utils;
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

        private void StartGlobalization()
        {
            LanguageInfo<string, string, int> languageInfo = new("en_us");
            languageInfo.textBookCollection = new();
            languageInfo.textBookCollection.Add("Home", new()
            {
                { 0, "Hello" },
                { 1, "Wellcome" }
            });
            
            _globalization = new(Consts.languageInfos, "pt_br");
            _globalization.LangTextObserver += Globalization_LangTextObserver;
            _globalization.StartGlobalization();
        }

        private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            congrats = _globalization.SetText("Home", 0);
            wellcome = _globalization.SetText("Home", 1);
        }
    }
}
