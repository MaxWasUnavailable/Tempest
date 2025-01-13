using UnityEngine;

namespace Tempest.Events;

/// <summary>
///     Events related to boats.
/// </summary>
public static class BoatEvents
{
    /// <summary>
    ///     Event handler for right before a boat overflows. Can be cancelled.
    /// </summary>
    public delegate void PreOverflowEventHandler(ref bool cancel);

    /// <summary>
    ///     Event handler for after a boat overflows.
    /// </summary>
    public delegate void PostOverflowEventHandler();

    /// <summary>
    ///     Raised before a boat overflows. Can be cancelled.
    /// </summary>
    public static event PreOverflowEventHandler? PreOverflowEvent;

    /// <summary>
    ///     Raised after a boat overflows.
    /// </summary>
    public static event PostOverflowEventHandler? PostOverflowEvent;

    /// <summary>
    ///     Event handler for right before a boat impacts. Can be cancelled.
    /// </summary>
    public delegate void PreImpactEventHandler(ref bool cancel);

    /// <summary>
    ///     Event handler for after a boat impacts.
    /// </summary>
    public delegate void PostImpactEventHandler();

    /// <summary>
    ///     Raised before a boat impacts. Can be cancelled.
    /// </summary>
    public static event PreImpactEventHandler? PreImpactEvent;

    /// <summary>
    ///     Raised after a boat impacts.
    /// </summary>
    public static event PostImpactEventHandler? PostImpactEvent;

    /// <summary>
    ///     Event handler for right after an item is added to a boat.
    /// </summary>
    public delegate void PostAddItemEventHandler(ref ItemRigidbody itemBody);

    /// <summary>
    ///     Raised after an item is added to a boat.
    /// </summary>
    public static event PostAddItemEventHandler? PostAddItemEvent;

    /// <summary>
    ///     Event handler for right after an item is removed from a boat.
    /// </summary>
    public delegate void PostRemoveItemEventHandler(ref ItemRigidbody itemBody);

    /// <summary>
    ///     Raised after an item is removed from a boat.
    /// </summary>
    public static event PostRemoveItemEventHandler? PostRemoveItemEvent;
    
    internal static void OnPostAddItem(ref ItemRigidbody itemBody)
    {
        PostAddItemEvent?.Invoke(ref itemBody);
    }
    
    internal static void OnPostRemoveItem(ref ItemRigidbody itemBody)
    {
        PostRemoveItemEvent?.Invoke(ref itemBody);
    }

    /// <summary>
    ///     Event handler for right before an item is added to a boat. Can be cancelled.
    /// </summary>
    public delegate void PreAddItemEventHandler(ref ItemRigidbody itemBody, ref bool cancel);

    /// <summary>
    ///     Raised before an item is added to a boat. Can be cancelled.
    /// </summary>
    public static event PreAddItemEventHandler? PreAddItemEvent;

    /// <summary>
    ///     Event handler for right before an item is removed from a boat. Can be cancelled.
    /// </summary>
    public delegate void PreRemoveItemEventHandler(ref ItemRigidbody itemBody, ref bool cancel);

    /// <summary>
    ///     Raised before an item is removed from a boat. Can be cancelled.
    /// </summary>
    public static event PreRemoveItemEventHandler? PreRemoveItemEvent;
    
    internal static bool OnPreAddItem(ref ItemRigidbody itemBody)
    {
        var cancel = false;
        PreAddItemEvent?.Invoke(ref itemBody, ref cancel);
        return cancel;
    }
    
    internal static bool OnPreRemoveItem(ref ItemRigidbody itemBody)
    {
        var cancel = false;
        PreRemoveItemEvent?.Invoke(ref itemBody, ref cancel);
        return cancel;
    }
    
    internal static bool OnPreOverflow()
    {
        var cancel = false;
        PreOverflowEvent?.Invoke(ref cancel);
        return cancel;
    }
    
    internal static void OnPostOverflow()
    {
        PostOverflowEvent?.Invoke();
    }
    
    internal static bool OnPreImpact()
    {
        var cancel = false;
        PreImpactEvent?.Invoke(ref cancel);
        return cancel;
    }
    
    internal static void OnPostImpact()
    {
        PostImpactEvent?.Invoke();
    }

    /// <summary>
    ///     Event handler for after all ropes are unmoored.
    /// </summary>
    public delegate void PostUnmoorAllRopesEventHandler();

    /// <summary>
    ///     Event handler for right before all ropes are unmoored. Can be cancelled.
    /// </summary>
    public delegate void PreUnmoorAllRopesEventHandler(ref bool cancel);

    /// <summary>
    ///     Event handler for after the closest rope is moored to a mooring.
    /// </summary>
    public delegate void PostMoorClosestRopeEventHandler(ref Transform mooring);

    /// <summary>
    ///     Event handler for right before the closest rope is moored to a mooring. Can be cancelled.
    /// </summary>
    public delegate void PreMoorClosestRopeEventHandler(ref Transform mooring, ref bool cancel);

    /// <summary>
    ///     Raised after all ropes are unmoored.
    /// </summary>
    public static event PostUnmoorAllRopesEventHandler? PostUnmoorAllRopesEvent;

    /// <summary>
    ///     Raised before all ropes are unmoored. Can be cancelled.
    /// </summary>
    public static event PreUnmoorAllRopesEventHandler? PreUnmoorAllRopesEvent;

    /// <summary>
    ///     Raised after the closest rope is moored to a mooring.
    /// </summary>
    public static event PostMoorClosestRopeEventHandler? PostMoorClosestRopeEvent;

    /// <summary>
    ///     Raised before the closest rope is moored to a mooring. Can be cancelled.
    /// </summary>
    public static event PreMoorClosestRopeEventHandler? PreMoorClosestRopeEvent;
    
    internal static void OnPostUnmoorAllRopes()
    {
        PostUnmoorAllRopesEvent?.Invoke();
    }
    
    internal static bool OnPreUnmoorAllRopes()
    {
        var cancel = false;
        PreUnmoorAllRopesEvent?.Invoke(ref cancel);
        return cancel;
    }
    
    internal static void OnPostMoorClosestRope(ref Transform mooring)
    {
        PostMoorClosestRopeEvent?.Invoke(ref mooring);
    }
    
    internal static bool OnPreMoorClosestRope(ref Transform mooring)
    {
        var cancel = false;
        PreMoorClosestRopeEvent?.Invoke(ref mooring, ref cancel);
        return cancel;
    }
}