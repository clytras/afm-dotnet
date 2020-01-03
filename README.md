# Greek TIN/AFM Validator and Generator

[![Linux Build Status](https://img.shields.io/travis/clytras/afm-dotnet.svg?style=flat)](https://travis-ci.org/clytras/afm-dotnet.svg?branch=master)

![Logo](https://github.com/clytras/afm-dotnet/raw/master/Resources/LytraxAFM_icon.png)

Validate and generate Greek TIN (*Tax Identification Number*) / AFM (*Αριθμός Φορολογικού Μητρώου*). Generation function can create valid or invalid numbers including parameters for old format, individuals, legal entities and repet tolerance digits control.

## Online demo and presentation

https://lytrax.io/blog/projects/greek-tin-validator-generator

## Installation

Using [NuGet Package Manager Console](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell):

```powershell
# Add the Lytrax.AFM package to the default project as specified in the console's project selector
Install-Package Lytrax.AFM

# Add the Lytrax.AFM package to a project named <MyProject> that is not the default
Install-Package Lytrax.AFM -ProjectName <MyProject>
```

## Usage

Import:

```cs
using Lytrax.AFM;
```

Validate a number:

```cs
> ValidateAFM.Validate("090000045")
true

> ValidateAFM.Validate("123456789")
false
```

Generate a valid number:

```cs
> GenerateAFM.GenerateValid()
"731385437"
```

Generate an invalid number:

```cs
> GenerateAFM.GenerateInvalid()
"853003357"
```

## API

Class **ValidateAFM**
* **Validate** *static boolean function*
  * `afm: string` - A number to be checked
  * **Returns**: `bool` - A boolean result indicating the validation of the number
* **ValidateExtended** *static `ValidateAFMExtendedResult` function*
  * `afm: string` - A number to be checked
  * **Returns**: `ValidateAFMExtendedResult` - Result indicating the validation of the number
* **constructor** *instantiates a new `ValidateAFM` object*
  * `afm: string` - A number to be checked
* **Number** *string property* - The current AFM number the class object contains
* **Valid** *bool property* - A boolean result indicating the validation of the current number the class object contains
* **Error** *string property* - A string result indicating the error if the current number the class object is invalid.<br/>
It can be empty or `"length"` or `"nan"` or `"zero"` or `"invalid"`


Class **ValidateAFMExtendedResult**
* **constructor** *instantiates a new `ValidateAFMExtendedResult` object*
  * `valid: bool` - Boolean indicates whether a number is valid or not
  * `error: string` - A string indicating the error if the number is invalid.<br/>
  It can be `"length"` or `"nan"` or `"zero"` or `"invalid"`
* **Valid** *boolean property* - Whether a number is valid or not
* **Error** *string property* - Empty or `"length"` or `"nan"` or `"zero"` or `"invalid"`

Example:
```cs
> ValidateAFM.ValidateExtended("ab1234")
ValidateAFMExtendedResult { Error="length", Valid=false }
```

Class **GenerateAFM**
* **Generate** *static string function*
  * `forceFirstDigit: int? = null` - If specified, overrides all pre99, legalEntity and individual
  * `pre99: bool = false` - Για ΑΦΜ πριν από 1/1/1999 (ξεκινάει με 0),<br/>
  (if true, overrides both legalEntity and individual)
  * `individual: bool = false` - Φυσικά πρόσωπα, (ξεκινάει με 1-4)
  * `legalEntity: bool = false` - Νομικές οντότητες (ξεκινάει με 7-9)
  * `repeatTolerance: int? = null` - Number for max repeat tolerance (0 for no repeats, unspecified for no check)
  * `valid: bool = true` - Generate valid or invalid AFM
  * **Returns**: `string` - A valid or invalid 9 digit AFM number

Example:
```cs
> GenerateAFM.Generate(forceFirstDigit: 3, repeatTolerance: 1, valid: true)
"335151580"
```

* **GenerateValid** *static string function* - Same as `Generate` with `valid` force and override to `true`
  * **Returns**: `string` - A valid 9 digit AFM number

Example:
```cs
> GenerateAFM.GenerateValid(pre99: true)
"070825250"
```

* **GenerateInvalid** *static string function* - Same as `Generate` with `valid` force and override to `false`
  * **Returns**: `string` - An invalid 9 digit AFM number

Example:
```cs
> GenerateAFM.GenerateInvalid(legalEntity: true)
"877577341"
```

## Test

Clone this repository:

```
git clone https://github.com/clytras/afm-dotnet.git && cd afm-dotnet
```

Open `Src\Lytrax.AFM\Lytrax.AFM.sln` using [Visual Strudio](https://visualstudio.microsoft.com/vs/community/) and run tests.

## Changelog

See [CHANGELOG](https://github.com/clytras/afm-dotnet/blob/master/CHANGELOG.md)

## License

MIT License - see the [LICENSE](https://github.com/clytras/afm-dotnet/blob/master/LICENSE) file for details
