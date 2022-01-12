using System.Collections.Generic;
using GlobalStrings.Types;

namespace GlobalStrings.Test.Utils
{
    public static class Consts
    {
        private static LanguageInfo<string, string, int> languagePtBr => new("pt_br", new(new()
        {
            { "Home", new()
            {
                {0, "Olá"},
                {1, "Seja Bem-Vindo"}
            }}
        }));

        private static LanguageInfo<string, string, int> languageEn => new("en_us", new(new()
        {
            {"Home", new()
            {
                { 0, "Hello" },
                { 1, "Wellcome" }
            }}
        }));

        public static List<LanguageInfo<string, string, int>> languageInfos => new() { languagePtBr, languageEn };
    }
}