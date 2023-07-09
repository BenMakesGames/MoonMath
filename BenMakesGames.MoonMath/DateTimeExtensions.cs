using System.Runtime.CompilerServices;

namespace BenMakesGames.MoonMath;

public static class DateTimeExtensions
{
    public const double MoonCycleLength = 29.53058868;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MoonPhase GetMoonPhase(double moonAge) => moonAge switch
    {
        < 1.84566 => MoonPhase.NewMoon,
        < 5.53699 => MoonPhase.WaxingCrescent,
        < 9.22831 => MoonPhase.FirstQuarter,
        < 12.91963 => MoonPhase.WaxingGibbous,
        < 16.61096 => MoonPhase.FullMoon,
        < 20.30228 => MoonPhase.WaningGibbous,
        < 23.99361 => MoonPhase.ThirdQuarter,
        < 27.68493 => MoonPhase.WaningCrescent,
        _ => MoonPhase.NewMoon
    };
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MoonPhase GetMoonPhase(this DateTimeOffset dt)
        => GetMoonPhase(GetMoonAge(dt.Year, dt.Month, dt.Day));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MoonPhase GetMoonPhase(this DateTime dt)
        => GetMoonPhase(GetMoonAge(dt.Year, dt.Month, dt.Day));

    public static long GetJulianDay(int year, int month, int day)
    {
        if (month < 3)
        {
            month += 12;
            year -= 1;
        }

        return day + (153 * month - 457) / 5 + 365 * year + (year / 4) - (year / 100) + (year / 400) + 1721119;
    }

    /// <summary>
    /// Returns the age of the moon in days. (0 = new moon, 14ish = full moon)
    /// </summary>
    public static double GetMoonAge(int year, int month, int day)
    {
        var julianDay = GetJulianDay(year, month, day);

        var interpolatedPhase = (julianDay - 2451550.1) / MoonCycleLength;

        // normalize interpolated phase to be between 0 and 1:
        interpolatedPhase -= Math.Floor(interpolatedPhase);

        if(interpolatedPhase < 0)
            interpolatedPhase++;

        return interpolatedPhase * MoonCycleLength;
    }
    
    /// <summary>
    /// Returns the age of the moon in days. (0 = new moon, 14ish = full moon)
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double GetMoonAge(this DateTimeOffset dt)
        => GetMoonAge(dt.Year, dt.Month, dt.Day);

    /// <summary>
    /// Returns the age of the moon in days. (0 = new moon, 14ish = full moon)
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double GetMoonAge(this DateTime dt)
        => GetMoonAge(dt.Year, dt.Month, dt.Day);
}
