# GlobalStrings
### Simple package that helps manage strings for implementing new languages in .NET applications

![](https://img.shields.io/nuget/v/GlobalStrings)
![](https://img.shields.io/nuget/dt/GlobalStrings)

### Dependencies
- .NET 5
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) (>= 13.0.1)

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

private Globalization<string, string, int> _globalization { get; set; }
private LanguageInfo<string, string, int> languagePtBr => new("pt_br", new(new()
{
    { "Home", new()
    {
        {0, "Olá"},
        {1, "Seja Bem-Vindo"}
    }}
}));

private LanguageInfo<string, string, int> languageEn => new("en_us", new(new()
{
    {"Home", new()
    {
        { 0, "Hello" },
        { 1, "Wellcome" }
    }}
}));

private string congrats;
private string wellcome;

public void ChangeLanguageTest()
{
    StartGlobalization();
    Assert.Equal("Olá", congrats);
    Assert.Equal("Seja Bem-Vindo", wellcome);

    _globalization.UpdateLang("en");

    Assert.Equal("Hello", congrats);
    Assert.Equal("Wellcome", wellcome);
}

private void StartGlobalization()
{
    _globalization = new(new() { languagePtBr, languageEn }, "pt_br");
    _globalization.LangTextObserver += Globalization_LangTextObserver;
    _globalization.StartGlobalization();
}

private void Globalization_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
{
   congrats = _globalization.SetText("Home", 0);
   wellcome = _globalization.SetText("Home", 1);
}
```

## Documentation
Access the [documentation here](https://github.com/LuanRoger/GlobalStrings/wiki).
