using HarmonyLib;
using Tempest.Events;

namespace Tempest.Patches;

[HarmonyPatch(typeof(Shopkeeper))]
[HarmonyPriority(Priority.First)]
[HarmonyWrapSafe]
internal static class ShopkeeperPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Shopkeeper.BuyItem))]
    private static bool ShopkeeperBuyItemPrefix(ref ShipItem item, ref int price)
    {
        return !EconomyEvents.OnPreBuyItem(ref item, ref price);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Shopkeeper.BuyItem))]
    private static void ShopkeeperBuyItemPostfix(ShipItem item, int price)
    {
        EconomyEvents.OnPostBuyItem(item, price);
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Shopkeeper.SellItem))]
    private static bool ShopkeeperSellItemPrefix(ref ShipItem item, ref int price, ref int currency)
    {
        return !EconomyEvents.OnPreSellItem(ref item, ref price, ref currency);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Shopkeeper.SellItem))]
    private static void ShopkeeperSellItemPostfix(ShipItem item, int price, int currency)
    {
        EconomyEvents.OnPostSellItem(item, price, currency);
    }
}