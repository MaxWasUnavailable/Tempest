namespace Tempest.Events;

/// <summary>
///     Events related to the economy.
/// </summary>
public static class EconomyEvents
{
    /// <summary>
    ///     Event handler for right before an item is bought by the shopkeep / sold by the player. Can be cancelled.
    /// </summary>
    public delegate void PreBuyItemEventHandler(ref ShipItem item, ref int price, ref bool cancel);

    /// <summary>
    ///     Event handler for after an item is bought by the shopkeep / sold by the player.
    /// </summary>
    public delegate void PostBuyItemEventHandler(ShipItem item, int price);

    /// <summary>
    ///     Event handler for right before an item is sold by the shopkeep / bought by the player. Can be cancelled.
    /// </summary>
    public delegate void PreSellItemEventHandler(ref ShipItem item, ref int price, ref int currency, ref bool cancel);

    /// <summary>
    ///     Event handler for after an item is sold by the shopkeep / bought by the player.
    /// </summary>
    public delegate void PostSellItemEventHandler(ShipItem item, int price, int currency);

    /// <summary>
    ///     Raised before an item is bought by the shopkeep / sold by the player. Can be cancelled.
    /// </summary>
    public static event PreBuyItemEventHandler? PreBuyItemEvent;

    /// <summary>
    ///     Raised after an item is bought by the shopkeep / sold by the player.
    /// </summary>
    public static event PostBuyItemEventHandler? PostBuyItemEvent;

    /// <summary>
    ///     Raised before an item is sold by the shopkeep / bought by the player. Can be cancelled.
    /// </summary>
    public static event PreSellItemEventHandler? PreSellItemEvent;

    /// <summary>
    ///     Raised after an item is sold by the shopkeep / bought by the player.
    /// </summary>
    public static event PostSellItemEventHandler? PostSellItemEvent;
    
    internal static bool OnPreBuyItem(ref ShipItem item, ref int price)
    {
        var cancel = false;
        PreBuyItemEvent?.Invoke(ref item, ref price, ref cancel);
        return cancel;
    }
    
    internal static void OnPostBuyItem(ShipItem item, int price)
    {
        PostBuyItemEvent?.Invoke(item, price);
    }
    
    internal static bool OnPreSellItem(ref ShipItem item, ref int price, ref int currency)
    {
        var cancel = false;
        PreSellItemEvent?.Invoke(ref item, ref price, ref currency, ref cancel);
        return cancel;
    }
    
    internal static void OnPostSellItem(ShipItem item, int price, int currency)
    {
        PostSellItemEvent?.Invoke(item, price, currency);
    }
}