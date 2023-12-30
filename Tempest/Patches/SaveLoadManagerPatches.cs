using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(SaveLoadManager))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class SaveLoadManagerPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(SaveLoadManager.LoadGame))]
    private static bool LoadGamePrefix()
    {
        return !SaveGameEvents.OnPreLoadGame(SaveSlots.currentSlot);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(SaveLoadManager.LoadGame))]
    private static void LoadGamePostfix()
    {
        SaveGameEvents.OnPostLoadGame(SaveSlots.currentSlot);
    }
    
    [HarmonyPrefix]
    [HarmonyPatch("DoSaveGame")]
    private static bool DoSaveGamePrefix()
    {
        return !SaveGameEvents.OnPreSaveGame(SaveSlots.currentSlot);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch("DoSaveGame")]
    private static void DoSaveGamePostfix()
    {
        SaveGameEvents.OnPostSaveGame(SaveSlots.currentSlot);
    }
}