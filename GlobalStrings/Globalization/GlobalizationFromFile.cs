using System.Linq;
using System.Reflection;
using GlobalStrings.Exeptions;
using GlobalStrings.Extensions.Serialization;

// ReSharper disable ParameterHidesMember

namespace GlobalStrings.Globalization
{
    public partial class Globalization<TLangCode, GCollectionCode, KTextCode>
    {
        private bool stringsByFile { get; set; }
        private string filepath { get; set; }
        
        private void StartFromFile(string filepath)
        {
            this.filepath = filepath;
            stringsByFile = true;
            this.LoadLanguageInfos(this.filepath);
        }
        /// <summary>
        /// Called by <c>GlobalizationJsonSerializer</c> loaders to Globalization identify the filepath correctly.
        /// </summary>
        /// <param name="filepath"></param>
        internal void LoadStringsFromFileJson(string filepath)
        {
            this.filepath = filepath;
            stringsByFile = true;
            OptimizeLangListByLangCode();
        }
        
        /// <summary>
        /// Get only the strings than the language will use, and dispose <c>languagesInfo</c>
        /// </summary>
        /// <exception cref="IsNotStringByFileException"></exception>
        private void OptimizeLangListByLangCode()
        {
            if(!stringsByFile)
                throw new IsNotStringByFileException(MethodBase.GetCurrentMethod()!.Name);
            
            actualLanguageInfo = languagesInfo.First(langInfo => langInfo.langCode.Equals(langCodeNow));
            languagesInfo = null;
        }
    }
}