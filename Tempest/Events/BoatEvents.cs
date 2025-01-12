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
    ///     Called before a boat overflows. Can be cancelled.
    /// </summary>
    public static event PreOverflowEventHandler? PreOverflowEvent;
    
    /// <summary>
    ///     Called after a boat overflows.
    /// </summary>
    public static event PostOverflowEventHandler? PostOverflowEvent;
    
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
}