using System.IO;
using System.Reflection;
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

        [Fact]
        public void SaveSerializationTest()
        {
            _globalization.SaveLanguageInfos(JSON_TEXT_PATH);
            
            Assert.True(File.Exists(JSON_TEXT_PATH));
        }
        [Fact]
        public void SaveSerializationAsyncTest()
        {
            SaveSerializationAsync();
        }
        
        [Fact]
        public void LoadSerializationAsyncTest()
        {
            LoadSerializationAsync();
        }
        [Fact]
        public void LoadSerializationByConstructorTest()
        {
            _globalization.SaveLanguageInfos(JSON_TEXT_PATH);
            
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
        private async void LoadSerializationAsync()
        {
            await _globalization.LoadLanguageInfosAsync(JSON_TEXT_PATH);
        }
        private async void SaveSerializationAsync()
        {
            await _globalization.SaveLanguageInfosAsync(JSON_TEXT_PATH);
        }
        #endregion
    }
}