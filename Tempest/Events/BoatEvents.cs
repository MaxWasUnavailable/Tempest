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
}