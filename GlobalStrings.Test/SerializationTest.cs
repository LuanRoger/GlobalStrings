using System.IO;
using GlobalStrings.EventArguments;
using GlobalStrings.Extensions;
using GlobalStrings.Globalization;
using GlobalStrings.Test.Utils;
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
            _globalization = new(Consts.languageInfos, "pt_br");
            _globalization.StartGlobalization();
        }
        private void CreateJsonFileToLoad()
        {
            lock (_globalization)
            {
                _globalization.SaveLanguageInfos(JSON_TEXT_PATH);
            }
        }

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
        [Fact]
        public void LoadSerializationAsyncTaskTest()
        {
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFileToLoad();
            
            LoadSerializationAsyncTask();
        }
        [Fact]
        public void LoadSerializationAsyncTest()
        {
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFileToLoad();
            
            _globalization.LoadLanguageInfosAsync(JSON_TEXT_PATH);
        }

        [Fact]
        public void LoadSerializationByConstructorTest()
        {
            if(!File.Exists(JSON_TEXT_PATH))
                CreateJsonFileToLoad();
            
            _globalization = new(JSON_TEXT_PATH, "pt_br");
            _globalization.LangTextObserver += GlobalizationOnLangTextObserver;
            
            _globalization.StartGlobalization();
            
            Assert.Equal("Olá", text);
        }

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