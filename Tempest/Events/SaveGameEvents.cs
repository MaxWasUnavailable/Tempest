namespace Tempest.Events;

/// <summary>
///     Events related to saving and loading.
/// </summary>
public static class SaveGameEvents
{
    public delegate void PostLoadGameEventHandler(int saveSlot);

    public delegate void PostNewGameEventHandler(int saveSlot);

    public delegate void PreLoadGameEventHandler(int saveSlot, ref bool cancel);

    public delegate void PreNewGameEventHandler(int saveSlot, ref bool cancel);

    /// <summary>
    ///     Called before a new game is started. Can be cancelled.
    /// </summary>
    public static event PreNewGameEventHandler? PreNewGameEvent;

    internal static bool OnPreNewGame(int saveSlot)
    {
        var cancel = false;
        PreNewGameEvent?.Invoke(saveSlot, ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after a new game is started.
    /// </summary>
    public static event PostNewGameEventHandler? PostNewGameEvent;

    internal static void OnPostNewGame(int saveSlot)
    {
        PostNewGameEvent?.Invoke(saveSlot);
    }

    /// <summary>
    ///     Called before a game is loaded. Can be cancelled.
    /// </summary>
    public static event PreLoadGameEventHandler? PreLoadGameEvent;

    internal static bool OnPreLoadGame(int saveSlot)
    {
        var cancel = false;
        PreLoadGameEvent?.Invoke(saveSlot, ref cancel);
        return cancel;
    }

    /// <summary>
    ///     Called after a game is loaded.
    /// </summary>
    public static event PostLoadGameEventHandler? PostLoadGameEvent;

    internal static void OnPostLoadGame(int saveSlot)
    {
        PostLoadGameEvent?.Invoke(saveSlot);
    }
}