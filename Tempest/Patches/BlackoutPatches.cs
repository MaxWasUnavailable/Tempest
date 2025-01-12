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
    private static bool BlackoutFadeToPrefix(float targetAlpha, float duration)
    {
        return !PlayerEvents.OnPreBlackout(targetAlpha, duration);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Blackout.FadeTo))]
    private static void BlackoutFadeToPostfix(float targetAlpha, float duration)
    {
        PlayerEvents.OnPostBlackout(targetAlpha, duration);
    }
}