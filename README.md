# What Is It?

`BenMakesGames.MoonMath` is a small library that adds extensions to `DateTime` and `DateTimeOffset` to calculate the phase of the Moon.

[![Buy Me a Coffee at ko-fi.com](https://raw.githubusercontent.com/BenMakesGames/AssetsForNuGet/main/buymeacoffee.png)](https://ko-fi.com/A0A12KQ16)

# How to Use

## Install

```powershell
dotnet add package BenMakesGames.MoonMath 
```

### Add `using`

```c#
using BenMakesGames.MoonMath;
```

## Reference

### `double DateTimeOffset.GetMoonAge()`

Computes The Moon's "age" - the number of Earth days since the last new moon. Ranges from 0 to ~29.53.

#### Example Use

```c#
var now = new DateTimeOffset();

Console.WriteLine($"It has been {now.GetMoonAge()} days since the last new moon.");
```

### `MoonPhase DateTimeOffset.GetMoonPhase()`

Returns a `MoonPhase` indicating the current phase of the Moon. `MoonPhase` has the following values:

* `NewMoon`
* `WaxingCrescent`
* `FirstQuarter`
* `WaxingGibbous`
* `FullMoon`
* `WaningGibbous`
* `ThirdQuarter`
* `WaningCrescent`

#### Example Use

```c#
var now = new DateTimeOffset();

var moonPhase = now.GetMoonPhase();
```

### `double DateTime.GetMoonAge()`

Same as `DateTimeOffset.GetMoonAge`, but for `DateTime`s.

### `MoonPhase DateTime.GetMoonPhase()`

Same as `DateTimeOffset.GetMoonPhase`, but for `DateTime`s.

### `string MoonPhase.ToEmoji()`

Returns the emoji for the given `MoonPhase`:

* 🌑 `NewMoon`
* 🌒 `WaxingCrescent`
* 🌓 `FirstQuarter`
* 🌔 `WaxingGibbous`
* 🌕 `FullMoon`
* 🌖 `WaningGibbous`
* 🌗 `ThirdQuarter`
* 🌘 `WaningCrescent`

#### Example use:

```c#
var now = new DateTimeOffset();

Console.WriteLine(now.GetMoonPhase().ToEmoji());
```



