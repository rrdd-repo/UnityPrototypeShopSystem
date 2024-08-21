using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyItem : MonoBehaviour
{
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private MoneyManager _moneyManager;
    
    //Items list in shop buttons
    [SerializeField]
    private Item[] _itemsToBuy;

    [SerializeField]
    private TMP_Text _alertText;

    private void Awake()
    {
        // Sets up shop
        foreach (Item item in _itemsToBuy) {
            _inventoryManager.SetShop(item);
        }
    }

    // When button pressed, adds item to inventory
    public void Purchase(int id)
    {
        // Only purchases if there's an item there, id -1 will be no item
        if (id > -1)
        {
            // If you have enough money, buys item
            if (_moneyManager.RemoveCoins(_itemsToBuy[id].startingPrice))
            {
                //If you have inventory space, adds item
                if (_inventoryManager.AddItem(_itemsToBuy[id]))
                {
                    _alertText.text = (_itemsToBuy[id].name + " Bought!").ToUpper();
                    // Changes your clothes to the item just bought
                    _inventoryManager.GetSelectedItem().ChangeCloth();

                }
                else
                {
                    // Adds money back up if inventory is full
                    _moneyManager.AddCoins(_itemsToBuy[id].startingPrice); 
                    _alertText.text = "Inventory Full!".ToUpper();
                }

            }
            else _alertText.text = "You don't have enough money!".ToUpper();
        } return;
    }

    
}
