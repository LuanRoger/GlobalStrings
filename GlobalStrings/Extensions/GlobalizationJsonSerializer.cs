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
        private static string SerializeLanguageInfos<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization) => 
            JsonConvert.SerializeObject(globalization.languagesInfo, Formatting.Indented);
        private static Task<string> SerializeLanguageInfosAsync<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization) => 
            Task.Factory.StartNew(() => JsonConvert.SerializeObject(globalization.languagesInfo, Formatting.Indented));

        #region SaveLanguageInfos
        /// <summary>
        /// Serializes all LanguageInfo from Globalization and saves it to a .json file.
        /// You can use this to save the LanguageInfo for the first time if you don't have a .json file.
        /// </summary>
        /// <param name="globalization">Globalization to get the LanguageInfo.</param>
        /// <param name="filePath">File path to save the LanguageInfo in JSON format. The file extension is .json.</param>
        /// <exception cref="IsNotJsonFileException">Throw if the file is not a .json file.</exception>
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
        /// <summary>
        /// Serializes all LanguageInfo from Globalization and saves it to a .json file asynchronously.
        /// You can use this to save the LanguageInfo for the first time if you don't have a .json file.
        /// </summary>
        /// <param name="globalization">Globalization to get the LanguageInfo.</param>
        /// <param name="filePath">File path to save the LanguageInfo in JSON format. The file extension is .json.</param>
        /// <exception cref="IsNotJsonFileException">Throw if the file is not a .json file.</exception>
        public static async void SaveLanguageInfosAsync<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);

            await using FileStream fileStream = new(filePath, FileMode.Create);
            await using StreamWriter streamWriter = new(fileStream);
            
            string jsonText = await globalization.SerializeLanguageInfosAsync();
            await streamWriter.WriteAsync(jsonText);
        }
        /// <summary>
        /// Serializes all LanguageInfo from Globalization and saves it to a .json file asynchronously.
        /// You can use this to save the LanguageInfo for the first time if you don't have a .json file.
        /// </summary>
        /// <param name="globalization">Globalization to get the LanguageInfo.</param>
        /// <param name="filePath">File path to save the LanguageInfo in JSON format. The file extension is .json.</param>
        /// <returns>Return the Write task.</returns>
        /// <exception cref="IsNotJsonFileException">Throw if the file is not a .json file.</exception>
        public static async Task SaveLanguageInfosAsyncTask<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);

            await using FileStream fileStream = new(filePath, FileMode.Create);
            await using StreamWriter streamWriter = new(fileStream);

            await globalization.SerializeLanguageInfosAsync()
                .ContinueWith(jsonTextTask => streamWriter.WriteAsync(jsonTextTask.Result));
        }
        #endregion

        #region LoadLanguageInfos
        /// <summary>
        /// Load all LanguageInfo from a .json file.
        /// </summary>
        /// <param name="globalization">Globalization to assign the loaded LanguageInfo.</param>
        /// <param name="filePath">.json file path to load the LanguageInfo.</param>
        /// <exception cref="IsNotJsonFileException">Throw if the file is not a .json file.</exception>
        public static void LoadLanguageInfos<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);
                
            string loadedJsonText;
            
            using (FileStream fileStream = new(filePath, FileMode.Open))
            using (StreamReader streamReader = new(fileStream))
                loadedJsonText = streamReader.ReadToEnd();

                
            globalization.languagesInfo = 
                JsonConvert.DeserializeObject<List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>>>(loadedJsonText);
        }
        /// <summary>
        /// Load all LanguageInfo from a .json file asynchronously.
        /// </summary>
        /// <param name="globalization">Globalization to assign the loaded LanguageInfo.</param>
        /// <param name="filePath">.json file path to load the LanguageInfo.</param>
        /// <exception cref="IsNotJsonFileException">Throw if the file is not a .json file.</exception>
        public static async void LoadLanguageInfosAsync<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath)
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);

            await using FileStream fileStream = new(filePath, FileMode.Open);
            using StreamReader streamReader = new(fileStream);
            
            string jsonText = await streamReader.ReadToEndAsync();
            globalization.languagesInfo = JsonConvert
                .DeserializeObject<List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>>>(jsonText);
        }
        /// <summary>
        /// Load all LanguageInfo from a .json file asynchronously.
        /// </summary>
        /// <param name="globalization">Globalization to assign the loaded LanguageInfo.</param>
        /// <param name="filePath">.json file path to load the LanguageInfo.</param>
        /// <returns>Return the DeserializeObject task.</returns>
        /// <exception cref="IsNotJsonFileException">Throw if the file is not a .json file.</exception>
        public static async Task LoadLanguageInfosAsyncTask<TLangCode, GCollectionCode, KTextCode>
            (this Globalization<TLangCode, GCollectionCode, KTextCode> globalization, string filePath) 
        {
            if(!Checkers.CheckJsonFileExtension(filePath))
                throw new IsNotJsonFileException(filePath);

            await using FileStream fileStream = new(filePath, FileMode.Open);
            using StreamReader streamReader = new(fileStream);
            
            string jsonText = await streamReader.ReadToEndAsync();
            globalization.languagesInfo = JsonConvert
                .DeserializeObject<List<LanguageInfo<TLangCode, GCollectionCode, KTextCode>>>(jsonText);
        }
        #endregion
    }
}