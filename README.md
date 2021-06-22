<h1 align="center">GlobalStrings</h1>
<h3 align="center">Simple package that helps manage strings for implementing new languages in .NET applications</h3>

<p>
   <img src="https://img.shields.io/nuget/v/GlobalStrings">
   <img src="https://img.shields.io/nuget/dt/GlobalStrings">
<p/>

## Dependencies
- .NET 5

## Installation
### PM
```
Install-Package GlobalStrings
```
### .NET CLI
```
dotnet add package GlobalStrings
```
See also in [Nuget Packages](https://www.nuget.org/packages/GlobalStrings)

## Simple example:
```csharp
using System.Collections.Generic;
using GlobalStrings;

Globalization<int, int, int> globalization;
private string congrats;
private string exit;
private string wellcome;

public void ChangeLanguageTest()
{
   Start();
   Assert.Equal("Olá", congrats);
   Assert.Equal("Seja Bem-Vindo", wellcome);

   globalization.UpdateLang(1);

   Assert.Equal("Hello", congrats);
   Assert.Equal("Wellcome", wellcome);
}

private void Start()
{
   LanguageInfo<int, int, int> languagePtBr = new(0);
   languagePtBr.textBookCollection = new();
   languagePtBr.textBookCollection.Add(0, new Dictionary<int, string>());
   languagePtBr.textBookCollection.Add(1, new Dictionary<int, string>());
   languagePtBr.textBookCollection[0].Add(0, "Olá");
   languagePtBr.textBookCollection[1].Add(0, "Seja Bem-Vindo");
   languagePtBr.textBookCollection[1].Add(1, "Sair");

   LanguageInfo<int, int, int> languageEn = new(1);
   languageEn.textBookCollection = new();
   languageEn.textBookCollection.Add(0, new Dictionary<int, string>());
   languageEn.textBookCollection.Add(1, new Dictionary<int, string>());
   languageEn.textBookCollection[0].Add(0, "Hello");
   languageEn.textBookCollection[1].Add(0, "Wellcome");
   languageEn.textBookCollection[1].Add(1, "Exit");

   List<LanguageInfo<int, int, int>> languageInfos = new(){languagePtBr, languageEn};

   globalization = new(languageInfos, 0);
   globalization.LangTextObserver += Globalization_LangTextObserver;

   globalization.StartGlobalization();
}

private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
{
   congrats = globalization.SetText(0, 0);
   wellcome = globalization.SetText(1, 0);
   exit = globalization.SetText(1, 1);
}
```
# Globalization
This is who will manage the existing [LanguageInfo](#languageinfo) and passed as a parameter in the Globalization constructor.
```csharp
Globalization(List<LanguageInfo<TLangCode, KTextCode, GCollectionCode>> languagesInfo, TLangCode langCodeNow)
```

To instantiate it you will need to have at least a List with at least two [LanguageInfo](#languageinfo), so:
```csharp
List<LanguageInfo<int, int, int>> languageInfos = new(){languagePtBr, languageEn};
globalization = new(languageInfos, 0);
```

### StartGlobalization
This is the method that will assign all initial language strings and therefore should only be used once.
```csharp
globalization.StartGlobalization();
```
> This alone will not work, if you want to skip other concepts [click here](#langtextobserver-and-settext)

### TLangCode, KTextCode and GCollectionCode
TLangCode, KTextCode and GCollectionCode are used to identify language, text and collection respectively, therefore, the types of Globalization<T, K, G> must be equal to LanguageInfo<T, K, G>.

Then:
```csharp
Globalization<string, int, int> globalization;
LanguageInfo<string, int, int> languagePtBr;
```
Even if you are not going to use collections, you must define a type for it.

# LanguageInfo
This is the class that will contain the information about the language, including the code and strings.
Like Globalization, LanguageInfo also has two types, one accepting generics and the other not:
```csharp
LanguageInfo<TLangCode, KTextCode, GCollectionCode>
```
> See section above for [more information](#tlangcode-ktextcode-and-gcollectioncode).

LanguageInfo can be instantiated with just the language code, but at some point you must assign a new ``` TextBookCollection<T, K, G> ``` or ``` Dictionary ``` to ``` textLangBook ```:
```csharp
LanguageInfo<int, int, int> languageEn = new(1);
languageEn.textBookCollection = new();
languageEn.textBookCollection.Add(0, new Dictionary<int, string>());
languageEn.textBookCollection.Add(1, new Dictionary<int, string>());
languageEn.textBookCollection[0].Add(0, "Hello");
languageEn.textBookCollection[1].Add(0, "Wellcome");
languageEn.textBookCollection[1].Add(1, "Exit");

// OR

LanguageInfo<int, int> languageEn = new(1, new Dictionary<int, string>() {
   { 0, "Hello" },
   { 1, "Wellcome" }
});
```
### LanguageInfo.TextBookCollection<T, K, G>
For each LanguageInfo you must have a TextBookCollection containing all the string collections you will use for that language.
Also, the codes assigned to string collections must be the same in their translations in other languages.
Ex:
```csharp
LanguageInfo<int, int, int> languagePtBr = new(0);
languagePtBr.textBookCollection = new();
languagePtBr.textBookCollection.Add(0, new Dictionary<int, string>());
languagePtBr.textBookCollection[0].Add(0, "Olá");

//OR

// This example uses textLangBook, which is currently deprecated.
// The difference is that it stores all strings without a division by collections,
// it's like a single collection to store all application strings
LanguageInfo<string, int> languageEn = new("en");
languageEn.textLangBook = new();
languageEn.textLangBook.Add(0, "Hello");

LanguageInfo<string, int> languagePtBr = new("pt_br");
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
   congrats = globalization.SetText(0, 0);
   wellcome = globalization.SetText(1, 0);
   
   //OR
   
   congrats = globalization.SetText(0);
   wellcome = globalization.SetText(1);
}
```
The parameter that is passed to SetText is the text code defined in ``` LanguageInfo.TextBookCollection ``` or ``` LanguageInfo.textLangBook ```
After that, you can call [StartGlobalization](#startglobalization) to assign.

### UpdateModeEventArgs
With this you can get information about the string assignment mode and the language, either by update (``` Update ```) or first startup (``` Insert ```).
```csharp
public sealed class UpdateModeEventArgs : EventArgs
{
   public UpdateMode mode { get; set; }
   public dynamic lang {get; internal set;}
}
```

With this you can also adjust the size of controls according to the language in applications with UI:
```csharp
private void Form1_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
{
   btnSizeDemo.Size = updateModeEventArgs.lang switch
   {
      "pt_br" => new Size(200, 23),
      "en" => new Size(190, 23)
   };
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
