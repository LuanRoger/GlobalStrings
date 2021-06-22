using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalStrings;

namespace GlobalStrings.Sample.Strings
{
    public static class Languages
    {
        public static void Init()
        {
            LanguageInfo<string, int, string> ptBr = new("pt_br");
            ptBr.textBookCollection = new();
            ptBr.textBookCollection.Add("Home", new Dictionary<int, string>());
            ptBr.textBookCollection["Home"].Add(0, "Olá");
            ptBr.textBookCollection["Home"].Add(1, "Mudar idioma");
            ptBr.textBookCollection["Home"].Add(2, "Esse botão muda seu tamanho");

            LanguageInfo<string, int, string> en = new("en");
            en.textBookCollection = new();
            en.textBookCollection.Add("Home", new Dictionary<int, string>());
            en.textBookCollection["Home"].Add(0, "Hello");
            en.textBookCollection["Home"].Add(1, "Change language");
            en.textBookCollection["Home"].Add(2, "This button changes its size");
            
            List<LanguageInfo<string, int, string>> languageList = new() {ptBr, en};

            Globalization<string, int, string>
            .SetGlobalizationInstance(new Globalization<string, int, string>(languageList, "pt_br"));
        }       
    }
}
