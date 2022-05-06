using System.Collections.Generic;
using GlobalStrings.EventArguments;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using GlobalStrings.Types.Enums;
using Xunit;

namespace GlobalStrings.Test
{
    public class EventArgsTest
    {
        private LanguageInfo<string, string, int> _languageInfoEnUs = new("en_us", new(new()
        {
            {"Home", new()
            {
                { 0, "Hello" }, 
                { 1, "Wellcome" }  
            }}
        }));
        private LanguageInfo<string, string, int> languageInfoPtBr = new("pt_br", new(new()
        {
            { "Home", new()
            {
                {0, "Olá"},
                {1, "Seja Bem-Vindo"}
            }}
        }));

        [Fact]
        public void StartEventArgsTest()
        {
            Globalization<string, string, int> globalization = 
                new(new List<LanguageInfo<string, string, int>> {_languageInfoEnUs, languageInfoPtBr},
                    "pt_br");
            globalization.LangTextObserver += GlobalizationOnLangTextObserverStart;
            globalization.StartGlobalization();
        }
        [Fact]
        public void UpdateLangEventArgsTest()
        {
            Globalization<string, string, int> globalization = 
                new(new List<LanguageInfo<string, string, int>> {_languageInfoEnUs, languageInfoPtBr},
                "pt_br");
            globalization.StartGlobalization();
            
            globalization.LangTextObserver += GlobalizationOnLangTextObserverUpdateLang;
            globalization.UpdateLang("en_us");
        }
        [Fact]
        public void SyncLangEventArgsTest()
        {
            Globalization<string, string, int> globalization = 
                new(new List<LanguageInfo<string, string, int>> {_languageInfoEnUs, languageInfoPtBr},
                "pt_br");
            globalization.StartGlobalization();
            
            globalization.LangTextObserver += GlobalizationOnLangTextObserverSyncLang;
            globalization.SyncStrings();
        }

        private void GlobalizationOnLangTextObserverSyncLang(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            Assert.Equal(UpdateMode.Sync, updatemodeeventargs.mode);
            Assert.Equal("pt_br", updatemodeeventargs.lang);
        }

        private void GlobalizationOnLangTextObserverUpdateLang(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            Assert.Equal(UpdateMode.Update, updatemodeeventargs.mode);
            Assert.Equal("en_us", updatemodeeventargs.lang);
        }

        private void GlobalizationOnLangTextObserverStart(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            Assert.Equal(UpdateMode.Start, updatemodeeventargs.mode);
            Assert.Equal("pt_br", updatemodeeventargs.lang);
        }
    }
}