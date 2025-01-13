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
    ///     Event handler for when the player enters a boat.
    /// </summary>
    public delegate void PostEnterBoatEventHandler();

    /// <summary>
    ///     Event handler for right before a player enters a boat. Can be cancelled.
    /// </summary>
    public delegate void PreEnterBoatEventHandler(ref bool cancel);

    /// <summary>
    ///     Event handler for when the player exits a boat.
    /// </summary>
    public delegate void PostExitBoatEventHandler();

    /// <summary>
    ///     Event handler for right before a player exits a boat. Can be cancelled.
    /// </summary>
    public delegate void PreExitBoatEventHandler(ref bool cancel);

    /// <summary>
    ///     Raised after the player enters a boat.
    /// </summary>
    public static event PostEnterBoatEventHandler? PostEnterBoatEvent;

    /// <summary>
    ///     Raised right before the player enters a boat. Can be cancelled.
    /// </summary>
    public static event PreEnterBoatEventHandler? PreEnterBoatEvent;

    /// <summary>
    ///     Raised after the player exits a boat.
    /// </summary>
    public static event PostExitBoatEventHandler? PostExitBoatEvent;

    /// <summary>
    ///     Raised right before the player exits a boat. Can be cancelled.
    /// </summary>
    public static event PreExitBoatEventHandler? PreExitBoatEvent;

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

    internal static void OnPostEnterBoat()
    {
        PostEnterBoatEvent?.Invoke();
    }

    internal static bool OnPreEnterBoat()
    {
        var cancel = false;
        PreEnterBoatEvent?.Invoke(ref cancel);
        return cancel;
    }

    internal static void OnPostExitBoat()
    {
        PostExitBoatEvent?.Invoke();
    }

    internal static bool OnPreExitBoat()
    {
        var cancel = false;
        PreExitBoatEvent?.Invoke(ref cancel);
        return cancel;
    }
}