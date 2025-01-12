namespace Tempest.Events;

/// <summary>
///     Events related to the player.
/// </summary>
public static class PlayerEvents
{
    /// <summary>
    ///     Event handler for when the player blacks out.
    /// </summary>
    public delegate void PostBlackoutEventHandler(ref float targetAlpha, ref float duration);

    /// <summary>
    ///     Event handler for right before a player blacks out. Can be cancelled.
    /// </summary>
    public delegate void PreBlackoutEventHandler(ref float targetAlpha, ref float duration, ref bool cancel);

    /// <summary>
    ///     Called after a player blacks out.
    /// </summary>
    public static event PostBlackoutEventHandler? PostBlackoutEvent;

    /// <summary>
    ///     Called right before a player blacks out. Can be cancelled.
    /// </summary>
    public static event PreBlackoutEventHandler? PreBlackoutEvent;

    internal static void OnPostBlackout(ref float targetAlpha, ref float duration)
    {
        PostBlackoutEvent?.Invoke(ref targetAlpha, ref duration);
    }
    
    internal static bool OnPreBlackout(ref float targetAlpha, ref float duration)
    {
        var cancel = false;
        PreBlackoutEvent?.Invoke(ref targetAlpha, ref duration, ref cancel);
        return cancel;
    }
}