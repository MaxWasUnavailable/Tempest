using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(Blackout))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class BlackoutPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Blackout.FadeTo))]
    private static bool BlackoutFadeToPrefix(ref float targetAlpha, ref float duration)
    {
        return !PlayerEvents.OnPreBlackout(ref targetAlpha, ref duration);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Blackout.FadeTo))]
    private static void BlackoutFadeToPostfix(ref float targetAlpha, ref float duration)
    {
        PlayerEvents.OnPostBlackout(ref targetAlpha, ref duration);
    }
}