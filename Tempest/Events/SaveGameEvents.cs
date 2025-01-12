namespace Tempest.Events;

/// <summary>
///     Events related to saving and loading.
/// </summary>
public static class SaveGameEvents
{
    /// <summary>
    ///     Event handler for when a game is loaded.
    /// </summary>
    public delegate void PostLoadGameEventHandler(ref int saveSlot);

    /// <summary>
    ///     Event handler for when a new game is started.
    /// </summary>
    public delegate void PostNewGameEventHandler(ref int saveSlot);

    /// <summary>
    ///     Event handler for when a game is saved.
    /// </summary>
    public delegate void PostSaveGameEventHandler(ref int saveSlot);
    
    /// <summary>
    ///     Event handler for right before a game is loaded. Can be cancelled.
    /// </summary>
    public delegate void PreLoadGameEventHandler(ref int saveSlot, ref bool cancel);

    /// <summary>
    ///     Event handler for right before a new game is started. Can be cancelled.
    /// </summary>
    public delegate void PreNewGameEventHandler(ref int saveSlot, ref bool cancel);

    /// <summary>
    ///     Event handler for right before a game is saved. Can be cancelled.
    /// </summary>
    public delegate void PreSaveGameEventHandler(ref int saveSlot, ref bool cancel);

    /// <summary>
    ///     Called before a new game is started. Can be cancelled.
    /// </summary>
    public static event PreNewGameEventHandler? PreNewGameEvent;

    internal static bool OnPreNewGame(ref int saveSlot)
    {
        var cancel = false;
        PreNewGameEvent?.Invoke(ref saveSlot, ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after a new game is started.
    /// </summary>
    public static event PostNewGameEventHandler? PostNewGameEvent;

    internal static void OnPostNewGame(ref int saveSlot)
    {
        PostNewGameEvent?.Invoke(ref saveSlot);
    }

    /// <summary>
    ///     Called before a game is loaded. Can be cancelled.
    /// </summary>
    public static event PreLoadGameEventHandler? PreLoadGameEvent;

    internal static bool OnPreLoadGame(ref int saveSlot)
    {
        var cancel = false;
        PreLoadGameEvent?.Invoke(ref saveSlot, ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after a game is loaded.
    /// </summary>
    public static event PostLoadGameEventHandler? PostLoadGameEvent;

    internal static void OnPostLoadGame(ref int saveSlot)
    {
        PostLoadGameEvent?.Invoke(ref saveSlot);
    }

    /// <summary>
    ///     Called before a game is saved. Can be cancelled.
    /// </summary>
    public static event PreSaveGameEventHandler? PreSaveGameEvent;

    internal static bool OnPreSaveGame(ref int saveSlot)
    {
        var cancel = false;
        PreSaveGameEvent?.Invoke(ref saveSlot, ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after a game is saved.
    /// </summary>
    public static event PostSaveGameEventHandler? PostSaveGameEvent;

    internal static void OnPostSaveGame(ref int saveSlot)
    {
        PostSaveGameEvent?.Invoke(ref saveSlot);
    }
}