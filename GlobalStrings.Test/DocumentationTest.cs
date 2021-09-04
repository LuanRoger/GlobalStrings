using System.Collections.Generic;
using GlobalStrings.Collection;
using GlobalStrings.Globalization;
using Xunit;

namespace GlobalStrings.Test
{
    public class DocumentationTest
    {
        [Fact]
        public void GlobalizationTest()
        {
            LanguageInfo<string, string, int> languagePtBr = new("pt_br");
            languagePtBr.textBookCollection = new();
            languagePtBr.textBookCollection.Add("Home", new()
            {
                {0, "Olá"},
                {1, "Seja Bem-Vindo"}
            });

            LanguageInfo<string, string, int> languageEn = new("en", new()
            {
                {"Home", new()
                {
                    { 0, "Hello" },
                    { 1, "Wellcome" }
                }}
            });

            Globalization<string, string, int> globalization = 
                new(new() {languagePtBr, languageEn}, "pt_br");
        }
        
        [Fact]
        public void LanguageInfoTest()
        {
            LanguageInfo<string, string, int> languagePtBr = new("pt_br");
            languagePtBr.textBookCollection = new();
            languagePtBr.textBookCollection.Add("Home", new()
            {
                {0, "Olá"},
                {1, "Seja Bem-Vindo"}
            });
            
            LanguageInfo<string, string, int> languageEn = new("en", new()
            {
                {"Home", new()
                {
                    { 0, "Hello" },
                    { 1, "Wellcome" }
                }}
            });
        }
        
        [Fact]
        public void TextLangBookTest()
        {
            TextBookCollection<int, int> textBookCollection = new();
            textBookCollection.Add(1, new()
            {
                { 0, "Hello" }
            });
            
            LanguageInfo<string, int, int> languageInfo = new("en", textBookCollection);
        }
    }
}