namespace BenMakesGames.MoonMath;

public enum MoonPhase
{
    NewMoon,
    WaxingCrescent,
    FirstQuarter,
    WaxingGibbous,
    FullMoon,
    WaningGibbous,
    ThirdQuarter,
    WaningCrescent
}

public static class MoonPhaseExtensions
{
    public static string ToEmoji(this MoonPhase phase) => phase switch
    {
        MoonPhase.NewMoon => "🌑",
        MoonPhase.WaxingCrescent => "🌒",
        MoonPhase.FirstQuarter => "🌓",
        MoonPhase.WaxingGibbous => "🌔",
        MoonPhase.FullMoon => "🌕",
        MoonPhase.WaningGibbous => "🌖",
        MoonPhase.ThirdQuarter => "🌗",
        MoonPhase.WaningCrescent => "🌘",
        _ => throw new ArgumentOutOfRangeException(nameof(phase), phase, null)
    };
}
