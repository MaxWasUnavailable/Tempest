using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;


[HarmonyPatch(typeof(BoatDamage))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class BoatEmbarkTriggerPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatEmbarkTrigger.EnterBoat))]
    private static bool BoatEmbarkTriggerEnterBoatPrefix()
    {
        return !PlayerEvents.OnPreEnterBoat();
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatEmbarkTrigger.EnterBoat))]
    private static void BoatEmbarkTriggerEnterBoatPostfix()
    {
        PlayerEvents.OnPostEnterBoat();
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatEmbarkTrigger.ExitBoat))]
    private static bool BoatEmbarkTriggerExitBoatPrefix()
    {
        return !PlayerEvents.OnPreExitBoat();
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatEmbarkTrigger.ExitBoat))]
    private static void BoatEmbarkTriggerExitBoatPostfix()
    {
        PlayerEvents.OnPostExitBoat();
    }
}