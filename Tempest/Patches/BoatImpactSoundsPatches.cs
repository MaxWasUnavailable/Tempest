using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(BoatImpactSounds))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class BoatImpactSoundsPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatImpactSounds.Impact))]
    private static bool BoatImpactSoundsImpactPrefix()
    {
        return !BoatEvents.OnPreImpact();
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatImpactSounds.Impact))]
    private static void BoatImpactSoundsImpactPostfix()
    {
        BoatEvents.OnPostImpact();
    }
}