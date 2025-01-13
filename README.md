# Tempest - An Event Library for Sailwind

Tempest is a simple, to-the-point event library for Sailwind. It is designed to be easy to use and easy to understand.

It offers pre- and post-event hooks, as well as the ability to cancel events through these pre-event hooks.
All variables are passed by reference, so you can modify them before or after the event.

## Example

```csharp
using Tempest.EconomyEvents;

public class MyStatisticsMod : BaseUnityPlugin
{
    public static float MoneySpent = 0;
    
    private void Awake()
    {
        EconomyEvents.PreSellItemEvent += MyPreSellItemEventMethod;
    }
    
    private void MyPreSellItemEventMethod(ref ShipItem item, ref int price, ref int currency, ref bool cancel
    {
        if (item.Name == "MySpecialItem")
        {
            cancel = true;
            return;
        }
        
        MoneySpent += price;
    }
}
```