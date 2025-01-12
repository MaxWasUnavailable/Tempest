using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(StartMenu))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class StartMenuPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(StartMenu.ButtonClick))]
    private static bool ButtonClickPrefix(StartMenuButtonType button)
    {
        if (button != StartMenuButtonType.NewGame) return true;
        
        return !SaveGameEvents.OnPreNewGame(ref SaveSlots.currentSlot);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(StartMenu.ButtonClick))]
    private static void ButtonClickPostfix(StartMenuButtonType button)
    {
        if (button != StartMenuButtonType.NewGame) return;
        
        SaveGameEvents.OnPostNewGame(ref SaveSlots.currentSlot);
    }
}