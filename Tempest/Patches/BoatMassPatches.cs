using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(BoatMass))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class BoatMassPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatMass.AddItem))]
    private static bool BoatMassAddItemPrefix(ref ItemRigidbody itemBody)
    {
        return BoatEvents.OnPreAddItem(ref itemBody);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatMass.AddItem))]
    private static void BoatMassAddItemPostfix(ref ItemRigidbody itemBody)
    {
        BoatEvents.OnPostAddItem(ref itemBody);
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(nameof(BoatMass.RemoveItem))]
    private static bool BoatMassRemoveItemPrefix(ref ItemRigidbody itemBody)
    {
        return BoatEvents.OnPreRemoveItem(ref itemBody);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoatMass.RemoveItem))]
    private static void BoatMassRemoveItemPostfix(ref ItemRigidbody itemBody)
    {
        BoatEvents.OnPostRemoveItem(ref itemBody);
    }
}