namespace Tempest.Events;

/// <summary>
///     Events related to the player.
/// </summary>
public static class PlayerEvents
{
    /// <summary>
    ///     Event handler for when the player blacks out.
    /// </summary>
    public delegate void PostBlackoutEventHandler(float targetAlpha, float duration);

    /// <summary>
    ///     Event handler for right before a player blacks out. Can be cancelled.
    /// </summary>
    public delegate void PreBlackoutEventHandler(float targetAlpha, float duration, ref bool cancel);

    /// <summary>
    ///     Called after a player blacks out.
    /// </summary>
    public static event PostBlackoutEventHandler? PostBlackoutEvent;

    /// <summary>
    ///     Called right before a player blacks out. Can be cancelled.
    /// </summary>
    public static event PreBlackoutEventHandler? PreBlackoutEvent;

    internal static void OnPostBlackout(float targetAlpha, float duration)
    {
        PostBlackoutEvent?.Invoke(targetAlpha, duration);
    }
    
    internal static bool OnPreBlackout(float targetAlpha, float duration)
    {
        var cancel = false;
        PreBlackoutEvent?.Invoke(targetAlpha, duration, ref cancel);
        return cancel;
    }
}