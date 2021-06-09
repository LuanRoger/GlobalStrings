using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalStrings;

namespace GlobalStrings.Sample.Strings
{
    public class Languages
    {
        public LanguageInfo<string, int> ptBr { get; set; }
        public LanguageInfo<string, int> en {get; set;}
        public List<LanguageInfo<string, int>> languageList { get {
                return new List<LanguageInfo<string, int>> {ptBr, en};
            }
        }

        public Languages()
        {
            ptBr = new("pt_br");
            Dictionary<int, string> ptBrDictionary = new();
            ptBrDictionary.Add(0, "Olá");
            ptBrDictionary.Add(1, "Mudar idioma");
            ptBrDictionary.Add(2, "Esse botão muda seu tamanho");
            ptBr.textLangBook = ptBrDictionary;

            en = new("en");
            Dictionary<int, string> enDictionary = new();
            enDictionary.Add(0, "Hello");
            enDictionary.Add(1, "Change language");
            enDictionary.Add(2, "This button changes its size");
            en.textLangBook = enDictionary;
        }
    }
}
