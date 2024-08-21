using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Inventory Slots for UI
    [SerializeField]
    private InventorySlot[] _inventorySlots;

    // Shop Slots for UI
    [SerializeField]
    private InventorySlot[] _shopSlots;

    // The item prefab that includes the inventoryItem
    public GameObject inventoryItemPrefab;

    // The item prefab that includes the shopItem
    public GameObject shopItemPrefab;

    [SerializeField]
    private Item[] _defaultClothes;

    // Check selected slot, will be used for the sell button
    int _selectedSlot = -1;
    
    // Don't think I'll have the time
    // But need to get the value from the inventory slot
    // (Maybe create id for the slots?)
    public void ChangeSelectedSlot(int newValue)
    {
        if(_selectedSlot >= 0) _inventorySlots[_selectedSlot].Deselect();

        _inventorySlots[newValue].Select();
        _selectedSlot = newValue;
    }

    public InventorySlot GetSelectedItem()
    {
        // Selected slot's inventory slot
        InventorySlot slot = _inventorySlots[_selectedSlot];
        // Item in slot
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

        // If item in slot isn't null then return's the slot (This is used for the sell button)
        if(itemInSlot != null)
        {
            return slot;
        }

        return null;
    }

    public bool AddItem(Item item)
    {
        // Will check every inventory slot
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            // Temporary variable for current slot
            InventorySlot slot = _inventorySlots[i];
            // Gets the item from child
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            // Will check every slot until there's a null one
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                ChangeSelectedSlot(slot.id);
                return true;
            }
        }

        return false;
    }

    // Spawns an item in the required slot
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemObj;

        // Creates item prefab in the slot position
        newItemObj = Instantiate(inventoryItemPrefab, slot.transform);

        // Takes the prefab's script and initialises the item
        InventoryItem inventoryItem = newItemObj.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item, false);
    }

    // Spawns an item in the required slot
    void SpawnShopItem(Item item, InventorySlot slot)
    {
        GameObject newItemObj;

        // Creates item prefab in the slot position
        newItemObj = Instantiate(shopItemPrefab, slot.transform);

        // Takes the prefab's script and initialises the item
        InventoryItem inventoryItem = newItemObj.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item, true);
  
    }

    public void SetShop(Item item)
    {
        // Will check every inventory slot
        foreach (InventorySlot slot in _shopSlots)
        {
            // If the slot id is equals to item id, item is spawned
            if (slot.id == item.id) SpawnShopItem(item, slot);
        }

    }

    // For the inventory button
    // When player presses the inventory button
    // First two slots will be default clothes
    public void SetDefault()
    {

        // Gets the item from child
        InventoryItem itemInSlot = _inventorySlots[0].GetComponentInChildren<InventoryItem>();

        // If the first slot is already a default cloth, skip the function
        if (itemInSlot != null) return;
        else
        {

            SpawnNewItem(_defaultClothes[0], _inventorySlots[0]);
            SpawnNewItem(_defaultClothes[1], _inventorySlots[1]);
        }

    }



}

