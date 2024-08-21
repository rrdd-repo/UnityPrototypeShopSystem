using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script goes in the child for the inventory slot
public class InventoryItem : MonoBehaviour
{
    
    [HideInInspector]
    public Item item;
    
    // Image for the item
    private Image _image;
    private TMP_Text _text;

    private void Awake()
    {
        // UI Image inside the slot
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TMP_Text>();
    }

    // Creates item with image in it
    public void InitialiseItem(Item newItem, bool isShopItem)
    {
        item = newItem;
        _image.sprite = newItem.icon;

        if (isShopItem)
        {
            _text.text = "$" + newItem.startingPrice;
        }
    }

}
