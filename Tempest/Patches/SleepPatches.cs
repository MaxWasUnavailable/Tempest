using HarmonyLib;
using Tempest.Events;
using UnityEngine;

namespace Tempest.Patches;


[HarmonyPatch(typeof(Sleep))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class SleepPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.EnterBed))]
    private static bool SleepEnterBedPrefix(Transform bed)
    {
        return SleepEvents.OnPreEnterBed(bed);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.EnterBed))]
    private static void SleepEnterBedPostfix(Transform bed)
    {
        SleepEvents.OnPostEnterBed(bed);
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.LeaveBed))]
    private static bool SleepLeaveBedPrefix()
    {
        return SleepEvents.OnPreLeaveBed();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.LeaveBed))]
    private static void SleepLeaveBedPostfix()
    {
        SleepEvents.OnPostLeaveBed();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.FallAsleep))]
    private static bool SleepFallAsleepPrefix()
    {
        return SleepEvents.OnPreFallAsleep();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.FallAsleep))]
    private static void SleepFallAsleepPostfix()
    {
        SleepEvents.OnPostFallAsleep();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.WakeUp))]
    private static bool SleepWakeUpPrefix()
    {
        return SleepEvents.OnPreWakeUp();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.WakeUp))]
    private static void SleepWakeUpPostfix()
    {
        SleepEvents.OnPostWakeUp();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.StartSleepTimeWarp))]
    private static bool SleepStartSleepTimeWarpPrefix()
    {
        return SleepEvents.OnPreStartSleepTimeWarp();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.StartSleepTimeWarp))]
    private static void SleepStartSleepTimeWarpPostfix()
    {
        SleepEvents.OnPostStartSleepTimeWarp();
    }
}