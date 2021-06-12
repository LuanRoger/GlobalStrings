<h1 align="center">GlobalStrings</h1>
<h3 align="center">Simple package that helps manage strings for implementing new languages in .NET applications</h3>

## Dependencies
- .NET 5

## Simple example:
```csharp
using System.Collections.Generic;
using GlobalStrings;

Globalization<string, int> globalization;
private string congrats;
private string wellcome;

public void ChangeLanguageTest()
{
   Start();
   Assert.Equal("Olá", congrats);
   Assert.Equal("Seja Bem-Vindo", wellcome);

   globalization.UpdateLang("en");

   Assert.Equal("Hello", congrats);
   Assert.Equal("Wellcome", wellcome);
}

private void Start()
{
   LanguageInfo<string, int> languagePtBr = new("pt_br");
   languagePtBr.textLangBook = new();
   languagePtBr.textLangBook.Add(0, "Olá");
   languagePtBr.textLangBook.Add(1, "Seja Bem-Vindo");

   LanguageInfo<string, int> languageEn = new("en");
   languageEn.textLangBook = new();
   languageEn.textLangBook.Add(0, "Hello");
   languageEn.textLangBook.Add(1, "Wellcome");

   List<LanguageInfo<string, int>> languageInfos = new(){languagePtBr, languageEn};

   globalization = new(languageInfos, "pt_br");
   globalization.LangTextObserver += Globalization_LangTextObserver;

   globalization.StartGlobalization();
}

private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
{
   congrats = globalization.SetText(0);
   wellcome = globalization.SetText(1);
}
```
# Globalization
This is who will manage the existing [LanguageInfo](#languageinfo) and passed as a parameter in the Globalization constructor.
There are two types of Globalization:
```csharp
Globalization(List<LanguageInfo<TLangCode, KTextCode>> languagesInfo, TLangCode langCodeNow) // 1
Globalization(List<LanguageInfo> languagesInfo, int langCodeNow) // 2
```
The first can be used with generic types, the second must be used with specific types.

- ``` List<LanguageInfo<TLangCode, KTextCode>> languagesInfo ``` <- List of all existing LanguageInfo.
  - ``` List<LanguageInfo> languagesInfo ``` <- Its non-generic variation.

- ``` TLangCode langCodeNow ``` <- Current language code, defined in any LanguageInfo
  - ``` int langCodeNow ``` <- Its non-generic variation.

To instantiate it you will need to have at least a List with at least two [LanguageInfo](#languageinfo), so:
```csharp
List<LanguageInfo<string, int>> languageInfos = new(){languagePtBr, languageEn};
globalization = new(languageInfos, "pt_br");
```

### StartGlobalization
This is the method that will assign all initial language strings and therefore should only be used once.
```csharp
globalization.StartGlobalization();
```
> This alone will not work, if you want to skip other concepts [click here](#langtextobserver-and-settext)

### TLangCode, KTextCode and non-generic
TLangCode and KTextCode are used to identify language and text respectively, therefore, the types of Globalization<T, K> must be equal to LanguageInfo<T, K>.

Then:
```csharp
Globalization<string, int> globalization;
LanguageInfo<string, int> languagePtBr;
```

The LanguageInfo and Globalization class use ``` int ``` to identify the language and text/string.

# LanguageInfo
This is the class that will contain the information about the language, including the code and strings.
Like Globalization, LanguageInfo also has two types, one accepting generics and the other not:
```csharp
LanguageInfo<TLangCode, KTextCode>
LanguageInfo
```
> See section above for [more information](#tlangcode-ktextcode-and-non-generic).

LanguageInfo can be instantiated with just the language code, but at some point you must assign a new ``` Dictionary ``` to ``` textLangBook ```:
```csharp
LanguageInfo<string, int> languageEn = new("en");
languageEn.textLangBook = new();
languageEn.textLangBook.Add(0, "Hello");
languageEn.textLangBook.Add(1, "Wellcome");
// OR
LanguageInfo<string, int> languageEn = new("en", new Dictionary<int, string>() {
   { 0, "Hello" },
   { 1, "Wellcome" }
});
```
### LanguageInfo.textLangBook
For each LanguageInfo you must have a textLangBook containing all the strings you will use for that language.
Also, the codes assigned to the strings must be the same in their translations in other languages.

Ex:
```csharp
LanguageInfo<string, int> languageEn = new("en"); //English
languageEn.textLangBook = new();
languageEn.textLangBook.Add(0, "Hello");

LanguageInfo<string, int> languagePtBr = new("pt_br"); // Portuguese
languagePtBr.textLangBook = new();
languagePtBr.textLangBook.Add(0, "Olá");
```

# LangTextObserver and SetText
``` LangTextObserver ``` is an event that will be called whenever the language is changed by ``` UpdateLang ```,thus, all strings within it will be updated.

For this to happen it is necessary to assign ``` SetText ``` to the strings inside the ``` LangTextObserver ````:
```csharp
globalization.LangTextObserver += Globalization_LangTextObserver;

private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
{
   congrats = globalization.SetText(0);
   wellcome = globalization.SetText(1);
}
```
The parameter that is passed to SetText is the text code defined in ``` LanguageInfo.textLangBook ```
After that, you can call [StartGlobalization](#startglobalization) to assign

### UpdateModeEventArgs
With this you can get information about the string assignment mode and the language, either by update (``` Update ```) or first startup (``` Insert ```).
```csharp
public sealed class UpdateModeEventArgs : EventArgs
{
   public UpdateMode mode { get; set; }
   public dynamic lang {get; internal set;}
}
```

# UpdateLang
This method is used to update strings in LangTextObserver, using the code defined in any LanguageInfo.
```csharp
globalization.UpdateLang("en");
```

# Exemples
- You can see the simple implementation example on the [top of the README](#simple-example)
- See also the sample project created in WinForms by [clicking here](https://github.com/LuanRoger/GlobalStrings/tree/main/GlobalStrings.Sample)
