using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour
{

    [SerializeField]
    private MoneyManager _moneyManager;
    [SerializeField]
    private InventoryManager _inventoryManager;
    
    public bool beingSold = false;

    // When button pressed, sells item and deletes it from inventory
    public void SellItem()
    {
        // Gets selected slot
        InventorySlot slot = _inventoryManager.GetSelectedItem();

        // If there's nothing in the slot, skip function
        if (slot == null) { beingSold = false; return; }

        // The item in the slot
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        
        // This variable is required for the check in Inventory Slot;
        beingSold = true;
            
        // Adds coins whenever item is sold    
        _moneyManager.AddCoins(itemInSlot.item.startingPrice);

        // Function will check if user is using the cloth or not before destroying   
        // If they are then it's gonna change to default, otherwise it'll stay the
        // current cloth

        slot.ChangeCloth();

        // Destroys item from slot
        Destroy(itemInSlot.gameObject);
        beingSold = false;
        }
 
}

