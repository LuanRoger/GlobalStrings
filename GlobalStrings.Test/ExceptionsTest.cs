using System.Collections.Generic;
using System.IO;
using GlobalStrings.EventArguments;
using GlobalStrings.Exeptions;
using GlobalStrings.Extensions.Serialization;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using Xunit;

namespace GlobalStrings.Test
{
    public class ExceptionsTest
    {
        private Globalization<string, string, int> _globalization { get; set; }
        private List<LanguageInfo<string, string, int>> languageInfos { get; set; }
        private readonly string INVALID_JSON_FILE = $@"{Directory.GetCurrentDirectory()}\Strings.js";

        public ExceptionsTest()
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
            languageInfos = new() { languageInfoEnUs, languageInfoPtBr };

            _globalization = new(languageInfos, "pt_br");
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
        public void UpdateLangNonExistentLangCodeTest()
        {
            Globalization<string, string, int> localGlobalization = new(languageInfos, "pt_br");
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
    }
}