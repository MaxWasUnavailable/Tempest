using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Tempest;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Tempest : BaseUnityPlugin
{
    private new static ManualLogSource? Logger { get; set; }
    internal static Tempest? Instance { get; private set; }
    private static Harmony? Harmony { get; set; }
    private static bool IsPatched { get; set; }

    private void Awake()
    {
        Instance = this;

        // Init logger
        Logger = base.Logger;

        Harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        PatchAll();

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    public void PatchAll()
    {
        if (IsPatched) return;
        Harmony!.PatchAll();
        IsPatched = true;
    }

    public void UnpatchAll()
    {
        if (!IsPatched) return;
        Harmony.UnpatchAll();
        IsPatched = false;
    }
}