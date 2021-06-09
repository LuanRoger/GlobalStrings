namespace GlobalStrings.Sample.Strings
{
    public static class LanguageManager
    {
        private static Globalization<string, int> globalization;
        private static Languages langs = new();
        
        public static Globalization<string, int> GetGlobalizationInstance()
        {
            if(globalization == null) globalization = new(langs.languageList, "pt_br");
            return globalization;
        }
    }
}
