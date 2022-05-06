using System.Collections.Generic;
using GlobalStrings.EventArguments;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using Xunit;

namespace GlobalStrings.Test
{
    public class SetTextTest
    {
        private Globalization<string, int, string> _globalization { get; set; }
        private string text1 { get; set; }
        private string text2 { get; set; }
        private string text3 { get; set; }
        private string text4 { get; set; }
        private string text5 { get; set; }
        private string text6 { get; set; } = null!;

        public SetTextTest()
        {
            StartGlobalization();
        }
        private void StartGlobalization()
        {
            LanguageInfo<string, int, string> languageInfoPtBr = new("pt_br", new()
            {
                {0, new()
                {
                    {"text1", "Olá"},
                    {"text2", "Bem-Vindo"},
                    {"text3", "Exemplo"},
                    {"text4", "Teste"},
                    {"text5", "Biblioteca"},
                    {"text6", "Baixe no {0} e no {1}"}
                }}
            });
            LanguageInfo<string, int, string> languageInfoEnUs = new("en_us", new()
            {
                {0, new()
                {
                    {"text1", "Hello"},
                    {"text2", "Wellcome"},
                    {"text3", "Example"},
                    {"text4", "Test"},
                    {"text5", "Library"},
                    {"text6", "Download on {0} and {1}"}

                }}
            });

            _globalization = new(new List<LanguageInfo<string, int, string>> { languageInfoPtBr, languageInfoEnUs }, "pt_br");
            _globalization.StartGlobalization();
        }
        private void CheckStrings(string langCode)
        {
            switch (langCode)
            {
                case "pt_br":
                    Assert.Equal("Olá", text1);
                    Assert.Equal("Bem-Vindo", text2);
                    Assert.Equal("Exemplo", text3);
                    Assert.Equal("Teste", text4);
                    Assert.Equal("Biblioteca", text5);
                    if(text6 is not null) Assert.Equal("Baixe no NuGet e no GitHub", text6);
                    break;
                case "en_us":
                    Assert.Equal("Hello", text1);
                    Assert.Equal("Wellcome", text2);
                    Assert.Equal("Example", text3);
                    Assert.Equal("Test", text4);
                    Assert.Equal("Library", text5);
                    if(text6 is not null) Assert.Equal("Download on NuGet and GitHub", text6);
                    break;
            }
        }
        
        [Fact]
        public void SimpleSetTextText()
        {
            _globalization.LangTextObserver += GlobalizationOnLangTextObserverSimple;
            _globalization.SyncStrings();
            text6 = null;
            
            CheckStrings("pt_br");
            _globalization.UpdateLang("en_us");
            CheckStrings("en_us");
        }
        [Fact]
        public void ValueKeyPairSetTextTest()
        {
            _globalization.LangTextObserver += GlobalizationOnLangTextObserverValueKeyPair;
            _globalization.SyncStrings();
            text6 = null;
            
            CheckStrings("pt_br");
            _globalization.UpdateLang("en_us");
            CheckStrings("en_us");
        }
        [Fact]
        public void ParamedSetTextTest()
        {
            _globalization.LangTextObserver += GlobalizationOnLangTextObserverParamedSetText;
            _globalization.SyncStrings();
            
            CheckStrings("pt_br");
            _globalization.UpdateLang("en_us");
            CheckStrings("en_us");
        }
        [Fact]
        public void ParamedValueKeyPairSetTextTest()
        {
            _globalization.LangTextObserver += GlobalizationOnLangTextObserverParamedValueKey;
            _globalization.SyncStrings();
            
            CheckStrings("pt_br");
            _globalization.UpdateLang("en_us");
            CheckStrings("en_us");
        }

        private void GlobalizationOnLangTextObserverParamedValueKey(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            text1 = _globalization.SetText(new(0, "text1"));
            text2 = _globalization.SetText(new(0, "text2"));
            text3 = _globalization.SetText(new(0, "text3"));
            text4 = _globalization.SetText(new(0, "text4"));
            text5 = _globalization.SetText(new(0, "text5"));
            text6 = _globalization.SetText(new KeyValuePair<int, string>(0, "text6"), "NuGet", "GitHub");
        }

        private void GlobalizationOnLangTextObserverParamedSetText(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            text1 = _globalization.SetText(0, "text1");
            text2 = _globalization.SetText(0, "text2");
            text3 = _globalization.SetText(0, "text3");
            text4 = _globalization.SetText(0, "text4");
            text5 = _globalization.SetText(0, "text5");
            text6 = _globalization.SetText(0, "text6", "NuGet", "GitHub");
        }

        private void GlobalizationOnLangTextObserverValueKeyPair(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            text1 = _globalization.SetText(new(0, "text1"));
            text2 = _globalization.SetText(new(0, "text2"));
            text3 = _globalization.SetText(new(0, "text3"));
            text4 = _globalization.SetText(new(0, "text4"));
            text5 = _globalization.SetText(new(0, "text5"));
        }

        private void GlobalizationOnLangTextObserverSimple(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            text1 = _globalization.SetText(0, "text1");
            text2 = _globalization.SetText(0, "text2");
            text3 = _globalization.SetText(0, "text3");
            text4 = _globalization.SetText(0, "text4");
            text5 = _globalization.SetText(0, "text5");
        }
    }
}