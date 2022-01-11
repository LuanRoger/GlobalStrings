using System.Collections.Generic;
using System.IO;
using GlobalStrings.Extensions;
using GlobalStrings.Globalization;
using GlobalStrings.Types;
using Xunit;
using Xunit.Abstractions;

namespace GlobalStrings.Test
{
    public class SerializationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SerializationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        private readonly string JSON_TEXT_PATH = $"{Directory.GetCurrentDirectory()}" + @"\Strings.json";
        
        private List<LanguageInfo<string, int, int>> _languageInfos { get; set; } = new(new []
        {
            new LanguageInfo<string, int, int>("pt_br", new(new()
            {
                {0, new()
                {
                    { 0, "Oi" }
                }}
            })),
            new LanguageInfo<string, int, int>("en_us", new(new()
            {
                {
                    0, new()
                    {
                        {0, "Hello"}
                    }
                }
            }))
        });
        private Globalization<string, int, int> globalization { get; set; }
        
        [Fact]
        public void SerializationOnlyTest()
        {
            globalization = new(_languageInfos, "pt_br");
            _testOutputHelper.WriteLine(globalization.SerializeLanguageInfos());
        }
        
        [Fact]
        public void SaveSerializationTest()
        {
            globalization = new(_languageInfos, "pt_br");
            globalization.SaveLanguageInfos(JSON_TEXT_PATH);
        }
        
        [Fact]
        public void LoadSerializationTest()
        {
            globalization = new(_languageInfos, "pt_br");
            globalization.LoadLanguageInfos(JSON_TEXT_PATH);
        }
    }
}