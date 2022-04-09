using System.Collections.Generic;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using Xunit;

namespace GlobalStrings.Test
{
    public class GlobalGlobalizationInstanceTest
    {
        public GlobalGlobalizationInstanceTest()
        {
            StarGlobalizationInstance();
        }
        private void StarGlobalizationInstance()
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
            
            GlobalGlobalization<string, string, int>.SetInstance(new(languageInfos, "pt_br"));
        }
        
        [Fact]
        public void GetGlobalizationInAutoInitialization()
        {
            lock (GlobalGlobalization<string, string, int>.GetInstance())
            {
                GlobalGlobalization<string, string, int>.ClearGlobalInstance();
            
                GlobalGlobalization<string, string, int>.autoInstanceIfNull = true;
                GlobalGlobalization<string, string, int>.GetInstance();
                
                Assert.NotNull(GlobalGlobalization<string, string, int>.GetInstance());
            }
        }
        
        [Fact]
        public void GetGlobalizationInstanceTest()
        {
            Assert.NotNull(GlobalGlobalization<string, string, int>.GetInstance());
        }
        
        [Fact]
        public void ClearGlobalGlobalizationInstanceTest()
        {
            lock (GlobalGlobalization<string, string, int>.GetInstance())
            {
                GlobalGlobalization<string, string, int>.ClearGlobalInstance();

                Assert.Null(GlobalGlobalization<string, string, int>.GetInstance());
            }
        }
    }
}