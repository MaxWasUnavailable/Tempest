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
}