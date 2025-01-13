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