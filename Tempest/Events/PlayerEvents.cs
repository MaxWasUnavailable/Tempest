using UnityEngine;

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

    /// <summary>
    ///     Event handler for when the player falls asleep.
    /// </summary>
    public delegate void PostFallAsleepEventHandler();

    /// <summary>
    ///     Event handler for when the player wakes up.
    /// </summary>
    public delegate void PostWakeUpEventHandler();

    /// <summary>
    ///     Event handler for when the player enters a bed.
    /// </summary>
    public delegate void PostEnterBedEventHandler(ref Transform bed);

    /// <summary>
    ///     Event handler for when the player leaves a bed.
    /// </summary>
    public delegate void PostLeaveBedEventHandler();

    /// <summary>
    ///     Event handler for when the player starts time warping while sleeping.
    /// </summary>
    public delegate void PostStartSleepTimeWarpEventHandler();

    /// <summary>
    ///     Called before the player falls asleep. Can be cancelled.
    /// </summary>
    public delegate void PreFallAsleepEventHandler(ref bool cancel);

    /// <summary>
    ///     Called before the player wakes up. Can be cancelled.
    /// </summary>
    public delegate void PreWakeUpEventHandler(ref bool cancel);

    /// <summary>
    ///     Called before the player enters a bed. Can be cancelled.
    /// </summary>
    public delegate void PreEnterBedEventHandler(ref Transform bed, ref bool cancel);

    /// <summary>
    ///     Called before the player leaves a bed. Can be cancelled.
    /// </summary>
    public delegate void PreLeaveBedEventHandler(ref bool cancel);

    /// <summary>
    ///     Called before the player starts time warping while sleeping. Can be cancelled.
    /// </summary>
    public delegate void PreStartSleepTimeWarpEventHandler(ref bool cancel);

    /// <summary>
    ///     Called before the player falls asleep. Can be cancelled.
    /// </summary>
    public static event PreFallAsleepEventHandler? PreFallAsleepEvent;
    
    internal static bool OnPreFallAsleep()
    {
        var cancel = false;
        PreFallAsleepEvent?.Invoke(ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after the player falls asleep.
    /// </summary>
    public static event PostFallAsleepEventHandler? PostFallAsleepEvent;
    
    internal static void OnPostFallAsleep()
    {
        PostFallAsleepEvent?.Invoke();
    }

    /// <summary>
    ///     Called before the player wakes up. Can be cancelled.
    /// </summary>
    public static event PreWakeUpEventHandler? PreWakeUpEvent;
    
    internal static bool OnPreWakeUp()
    {
        var cancel = false;
        PreWakeUpEvent?.Invoke(ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after the player wakes up.
    /// </summary>
    public static event PostWakeUpEventHandler? PostWakeUpEvent;
    
    internal static void OnPostWakeUp()
    {
        PostWakeUpEvent?.Invoke();
    }

    /// <summary>
    ///     Called before the player enters a bed. Can be cancelled.
    /// </summary>
    public static event PreEnterBedEventHandler? PreEnterBedEvent;
    
    internal static bool OnPreEnterBed(ref Transform bed)
    {
        var cancel = false;
        PreEnterBedEvent?.Invoke(ref bed, ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after the player enters a bed.
    /// </summary>
    public static event PostEnterBedEventHandler? PostEnterBedEvent;
    
    internal static void OnPostEnterBed(ref Transform bed)
    {
        PostEnterBedEvent?.Invoke(ref bed);
    }

    /// <summary>
    ///     Called before the player leaves a bed. Can be cancelled.
    /// </summary>
    public static event PreLeaveBedEventHandler? PreLeaveBedEvent;
    
    internal static bool OnPreLeaveBed()
    {
        var cancel = false;
        PreLeaveBedEvent?.Invoke(ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after the player leaves a bed.
    /// </summary>
    public static event PostLeaveBedEventHandler? PostLeaveBedEvent;
    
    internal static void OnPostLeaveBed()
    {
        PostLeaveBedEvent?.Invoke();
    }

    /// <summary>
    ///     Called before the player starts time warping while sleeping. Can be cancelled.
    /// </summary>
    public static event PreStartSleepTimeWarpEventHandler? PreStartSleepTimeWarpEvent;
    
    internal static bool OnPreStartSleepTimeWarp()
    {
        var cancel = false;
        PreStartSleepTimeWarpEvent?.Invoke(ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after the player starts time warping while sleeping.
    /// </summary>
    public static event PostStartSleepTimeWarpEventHandler? PostStartSleepTimeWarpEvent;
    
    internal static void OnPostStartSleepTimeWarp()
    {
        PostStartSleepTimeWarpEvent?.Invoke();
    }
}