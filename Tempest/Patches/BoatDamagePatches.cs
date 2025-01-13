using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(BoatDamage))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class BoatDamagePatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatDamage.Overflow))]
    private static bool BoatDamageOverflowPrefix()
    {
        return !BoatEvents.OnPreOverflow();
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatDamage.Overflow))]
    private static void BoatDamageOverflowPostfix()
    {
        BoatEvents.OnPostOverflow();
    }
}