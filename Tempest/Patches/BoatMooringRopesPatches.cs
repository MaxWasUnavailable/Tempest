using HarmonyLib;
using Tempest.Events;
using UnityEngine;

namespace Tempest.Patches;

[HarmonyPatch(typeof(BoatMooringRopes))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class BoatMooringRopesPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatMooringRopes.UnmoorAllRopes))]
    private static bool BoatMooringRopesUnmoorAllRopesPrefix()
    {
        return !BoatEvents.OnPreUnmoorAllRopes();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatMooringRopes.UnmoorAllRopes))]
    private static void BoatMooringRopesUnmoorAllRopesPostfix()
    {
        BoatEvents.OnPostUnmoorAllRopes();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatMooringRopes.MoorClosestRope))]
    private static bool BoatMooringRopesMoorClosestRopePrefix(ref Transform mooring)
    {
        return !BoatEvents.OnPreMoorClosestRope(ref mooring);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatMooringRopes.MoorClosestRope))]
    private static void BoatMooringRopesMoorClosestRopePostfix(ref Transform mooring)
    {
        BoatEvents.OnPostMoorClosestRope(ref mooring);
    }
}