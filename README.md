# GlobalStrings
### Simple package that helps manage strings for implementing new languages in .NET applications

![](https://img.shields.io/nuget/v/GlobalStrings)
![](https://img.shields.io/nuget/dt/GlobalStrings)

### Dependencies
- .NET 5

## Installation
### PM
```powershell
Install-Package GlobalStrings
```
### .NET CLI
```powershell
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

    Globalization<string, string, int>.GetGlobalizationInstance().UpdateLang("en");

    Assert.Equal("Hello", congrats);
    Assert.Equal("Wellcome", wellcome);
}

private void Start()
{
    LanguageInfo<string, string, int> languagePtBr = new("pt_br");
    languagePtBr.textBookCollection = new();
    languagePtBr.textBookCollection.Add("Home", new()
    {
        {0, "Olá"},
        {1, "Seja Bem-Vindo"}
    });

    LanguageInfo<string, string, int> languageEn = new("en", new()
    {
        {"Home", new()
        {
            { 0, "Hello" },
            { 1, "Wellcome" }
         }}
    });

    List<LanguageInfo<string, string, int>> languageInfos = new(){ languagePtBr, languageEn };;

    Globalization<string, string, int>.SetGlobalizationInstance(new(languageInfos, "pt_br"));
    Globalization<string, string, int>.GetGlobalizationInstance().LangTextObserver += Globalization_LangTextObserver;

    Globalization<string, string, int>.GetGlobalizationInstance().StartGlobalization();
}

private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
{
   congrats = Globalization<string, string, int>.GetGlobalizationInstance().SetText("Home", 0);
   wellcome = Globalization<string, string, int>.GetGlobalizationInstance().SetText("Home", 1);
}
```

# Documentation
Access the [documentation here](https://github.com/LuanRoger/GlobalStrings/wiki).
