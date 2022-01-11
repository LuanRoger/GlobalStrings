using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GlobalStrings.Exeptions;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using GlobalStrings.Utils;
using Newtonsoft.Json;

namespace GlobalStrings.Extensions
{
    public static class GlobalizationJsonSerializer
    {
        public static string SerializeLanguageInfos<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization) =>
                JsonConvert.SerializeObject(globalization.languagesInfo, Formatting.Indented);

        #region SaveLanguageInfos
        public static void SaveLanguageInfos<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);
            
            string jsonText = globalization.SerializeLanguageInfos();

            using FileStream fileStream = new(filePath, FileMode.Create);
            using StreamWriter streamWriter = new(fileStream); 
            
            streamWriter.Write(jsonText);
        }
        public static Task SaveLanguageInfosAsync<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);
            
            string jsonText = globalization.SerializeLanguageInfos();

            using FileStream fileStream = new(filePath, FileMode.Create);
            using StreamWriter streamWriter = new(fileStream);
            
            return streamWriter.WriteAsync(jsonText);
        }
        #endregion

        #region LoadLanguageInfos
        public static void LoadLanguageInfos<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);
                
            string loadedJsonText = string.Empty;
            
            using (FileStream fileStream = new(filePath, FileMode.Open))
            using (StreamReader streamReader = new(fileStream))
                loadedJsonText = streamReader.ReadToEnd();

                
            globalization.languagesInfo = 
                JsonConvert.DeserializeObject<List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>>>(loadedJsonText);
        }
        public static async Task LoadLanguageInfosAsync<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath) 
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);
            
            string loadedJsonText = string.Empty;

            await using (FileStream fileStream = new(filePath, FileMode.Open))
            using (StreamReader streamReader = new(fileStream))
                loadedJsonText = await streamReader.ReadToEndAsync();

            globalization.languagesInfo = 
                JsonConvert.DeserializeObject<List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>>>(loadedJsonText);
        }
        #endregion
    }
}