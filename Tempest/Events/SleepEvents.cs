using UnityEngine;

namespace Tempest.Events;

/// <summary>
///     Events related to sleeping.
/// </summary>
public static class SleepEvents
{
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