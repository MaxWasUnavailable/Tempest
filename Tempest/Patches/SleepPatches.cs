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
    private static bool SleepEnterBedPrefix(ref Transform bed)
    {
        return PlayerEvents.OnPreEnterBed(ref bed);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.EnterBed))]
    private static void SleepEnterBedPostfix(ref Transform bed)
    {
        PlayerEvents.OnPostEnterBed(ref bed);
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.LeaveBed))]
    private static bool SleepLeaveBedPrefix()
    {
        return PlayerEvents.OnPreLeaveBed();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.LeaveBed))]
    private static void SleepLeaveBedPostfix()
    {
        PlayerEvents.OnPostLeaveBed();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.FallAsleep))]
    private static bool SleepFallAsleepPrefix()
    {
        return PlayerEvents.OnPreFallAsleep();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.FallAsleep))]
    private static void SleepFallAsleepPostfix()
    {
        PlayerEvents.OnPostFallAsleep();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.WakeUp))]
    private static bool SleepWakeUpPrefix()
    {
        return PlayerEvents.OnPreWakeUp();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.WakeUp))]
    private static void SleepWakeUpPostfix()
    {
        PlayerEvents.OnPostWakeUp();
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Sleep.StartSleepTimeWarp))]
    private static bool SleepStartSleepTimeWarpPrefix()
    {
        return PlayerEvents.OnPreStartSleepTimeWarp();
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Sleep.StartSleepTimeWarp))]
    private static void SleepStartSleepTimeWarpPostfix()
    {
        PlayerEvents.OnPostStartSleepTimeWarp();
    }
}