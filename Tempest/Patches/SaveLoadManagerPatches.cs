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
        return !SaveGameEvents.OnPreLoadGame(ref SaveSlots.currentSlot);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(SaveLoadManager.LoadGame))]
    private static void LoadGamePostfix()
    {
        SaveGameEvents.OnPostLoadGame(ref SaveSlots.currentSlot);
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(SaveLoadManager.DoSaveGame))]
    private static bool DoSaveGamePrefix()
    {
        return !SaveGameEvents.OnPreSaveGame(ref SaveSlots.currentSlot);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(SaveLoadManager.DoSaveGame))]
    private static void DoSaveGamePostfix()
    {
        SaveGameEvents.OnPostSaveGame(ref SaveSlots.currentSlot);
    }
}