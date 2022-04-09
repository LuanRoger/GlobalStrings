using System.Collections.Generic;
using System.IO;
using GlobalStrings.EventArguments;
using GlobalStrings.Extensions.Serialization;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using Xunit;

namespace GlobalStrings.Test
{
    public class SerializationTest
    {
        private Globalization<string, string, int> _globalization { get; set; }
        
        private readonly string JSON_TEXT_PATH = $@"{Directory.GetCurrentDirectory()}\Strings.json";
        private string text;

        public SerializationTest()
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
            List<LanguageInfo<string, string, int>> languageInfos = new() { languageInfoEnUs, languageInfoPtBr };
            
            _globalization = new(languageInfos, "pt_br");
            _globalization.StartGlobalization();
        }
        private void CreateJsonFile()
        {
            lock (_globalization)
            {
                _globalization.SaveLanguageInfos(JSON_TEXT_PATH);
            }
        }

        #region SaveTest
        [Fact]
        public void SaveSerializationTest()
        {
            _globalization.SaveLanguageInfos(JSON_TEXT_PATH);

            Assert.True(File.Exists(JSON_TEXT_PATH));
        }
        [Fact]
        public void SaveSerializationAsyncTaskTest()
        {
            SaveSerializationAsyncTask();
        }
        [Fact]
        public void SaveSerializationAsyncTest()
        {
            _globalization.SaveLanguageInfosAsync(JSON_TEXT_PATH);
        }
        #endregion

        #region LoadTest
        [Fact]
        public void LoadSerializationAsyncTaskTest()
        {
            StartGlobalization();
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFile();
            
            LoadSerializationAsyncTask();
        }
        [Fact]
        public void LoadSerializationAsyncTest()
        {
            StartGlobalization();
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFile();
            
            _globalization.LoadLanguageInfosAsync(JSON_TEXT_PATH);
            _globalization.LangTextObserver += GlobalizationOnLangTextObserver;
            _globalization.StartGlobalization();
            
            Assert.Equal("Olá", text);
        }

        [Fact]
        public void LoadSerializationByConstructorTest()
        {
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFile();
            
            _globalization = new(JSON_TEXT_PATH, "pt_br");
            _globalization.LangTextObserver += GlobalizationOnLangTextObserver;
            _globalization.StartGlobalization();
            
            Assert.Equal("Olá", text);
        }
        [Fact]
        public void LoadSerializationByConstructorUpdateLangTest()
        {
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFile();
            
            _globalization = new(JSON_TEXT_PATH, "pt_br");
            _globalization.LangTextObserver += GlobalizationOnLangTextObserver;
            _globalization.StartGlobalization();
            
            Assert.Equal("Olá", text);
            
            _globalization.UpdateLang("en_us");
            
            Assert.Equal("Hello", text);
        }
        #endregion

        private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            text = _globalization.SetText("Home", 0);
        }

        #region AsyncTasks
        private async void SaveSerializationAsyncTask()
        {
            await _globalization.SaveLanguageInfosAsyncTask(JSON_TEXT_PATH);
        }
        private async void LoadSerializationAsyncTask()
        {
            await _globalization.LoadLanguageInfosAsyncTask(JSON_TEXT_PATH);
        }
        #endregion
    }
}