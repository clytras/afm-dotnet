# Greek TIN/AFM Validator and Generator

[![Linux Build Status](https://img.shields.io/travis/clytras/afm-es.svg?style=flat)](https://travis-ci.org/clytras/afm-es.svg?branch=master)


Validate and generate Greek TIN (*Tax Identification Number*) / AFM (*Αριθμός Φορολογικού Μητρώου*). Generation function can create valid or invalid numbers including parameters for old format, individuals, legal entities and repet tolerance digits control.

## Online demo

https://lytrax.io

## Installation

## Usage

Import or require:

```cs
```

Validate a number:

```cs
```

Generate a valid number:

```cs
```

Generate an invalid number:

```cs
```

## API

**validateAFM** `(afm, [{ extendedResult = false }])`
* `afm: string` - A number to be checked
* `[params: object]` - Optional object for named parameters
* `[params.extendedResult: boolean = false]` - Return a `boolean` or `ValidateAFMExtendedResult`
* **Returns**: `boolean` or `ValidateAFMExtendedResult`

Example:
```js
> validateAFM('ab1234', { extendedResult: true })
< {valid: false, error: "length"}
```

**generateAFM** `([{`<br>
&nbsp;&nbsp;` forceFirstDigit,`<br>
&nbsp;&nbsp;` pre99 = false,`<br>
&nbsp;&nbsp;` individual = false,`<br>
&nbsp;&nbsp;` legalEntity = false,`<br>
&nbsp;&nbsp;` repeatTolerance,`<br>
&nbsp;&nbsp;` valid = true`<br>
`}])`
* `[params: object]` - Optional object for named parameters
* `[params.forceFirstDigit: null|number]` - If specified, overrides all pre99, legalEntity and individual
* `[params.pre99: boolean = false]` - Για ΑΦΜ πριν από 1/1/1999 (ξεκινάει με 0), (if true, overrides both legalEntity and individual)
* `[params.individual: boolean = false]` - Φυσικά πρόσωπα, (ξεκινάει με 1-4)
* `[params.legalEntity: boolean = false]` - Νομικές οντότητες (ξεκινάει με 7-9)
* `[params.repeatTolerance: null|number]` - Number for max repeat tolerance (0 for no repeats, unspecified for no check)
* `[params.valid: boolean = true]` - Generate valid or invalid AFM
* **Returns**: `string` - A valid or invalid 9 digit AFM number

Example:
```js
> generateAFM({ forceFirstDigit: 3, repeatTolerance: 1, valid: true })
< "335151580"
```

**generateValidAFM** - Same as `generateAFM` with `params.valid` force and override to `true`
* **Returns**: `string` - A valid 9 digit AFM number

Example:
```js
> generateValidAFM({ pre99: true })
< "070825250"
```

**generateInvalidAFM** - Same as `generateAFM` with `params.valid` force and override to `false`
* **Returns**: `string` - An invalid 9 digit AFM number

Example:
```js
> generateInvalidAFM({ legalEntity: true })
< "877577341"
```

## Test

Clone this repository, intall modules and run test:

```
git clone https://github.com/clytras/afm-dotnet.git && cd afm-dotnet

```

## License

MIT License - see the [LICENSE](LICENSE) file for details
