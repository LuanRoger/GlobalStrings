using System.IO;
using GlobalStrings.EventArguments;
using GlobalStrings.Exeptions;
using GlobalStrings.Extensions;
using GlobalStrings.Globalization;
using GlobalStrings.Test.Utils;
using Xunit;

namespace GlobalStrings.Test
{
    public class ExceptionsTest
    {
        private Globalization<string, string, int> _globalization { get; set; }
        private readonly string INVALID_JSON_FILE = $@"{Directory.GetCurrentDirectory()}\Strings.js";
        
        private string text;

        public ExceptionsTest()
        {
            StartGlobalization();
        }
        
        private void StartGlobalization()
        {
            _globalization = new(Consts.languageInfos, "pt_br");
            _globalization.LangTextObserver += GlobalizationOnLangTextObserver;
        }
        
        [Fact]
        public void SetTextExceptionTest()
        {
            Assert.Throws<StopedGlobalizationExeption>(_globalization.SyncStrings);
        }
        
        [Fact]
        public void UpdateLangExceptionTest()
        {
            Assert.Throws<StopedGlobalizationExeption>(() => _globalization.UpdateLang("en_us"));
        }
        [Fact]
        public void UpdateLangNonexistentLangCodeTest()
        {
            Globalization<string, string, int> localGlobalization = new(Consts.languageInfos, "pt_br");
            localGlobalization.StartGlobalization();
            
            Assert.Throws<IncorrectLangCodeException>(() => localGlobalization.UpdateLang("en"));
        }
        
        [Fact]
        public void IsNotJsonFileInSaveExceptionTest()
        {
            Assert.Throws<IsNotJsonFileException>(() => _globalization.SaveLanguageInfos(INVALID_JSON_FILE));
        }
        [Fact]
        public void IsNotJsonFileInLoadExceptionTest()
        {
            Assert.Throws<IsNotJsonFileException>(() => _globalization.LoadLanguageInfos(INVALID_JSON_FILE));
        }
        
        private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            text = _globalization.SetText("Home", 0);
        }
    }
}