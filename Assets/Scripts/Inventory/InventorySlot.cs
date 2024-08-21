using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Sprite resolver library
using UnityEngine.U2D.Animation;

public class InventorySlot : MonoBehaviour
{
    // Inventory Slot Id
    public int id;
    // List of all body parts
    [SerializeField]
    private GameObject[] _bodyParts;
    // The body part that's gonna be changed
    private GameObject _correctBodyPart;

    [SerializeField]
    private InventoryManager _inventoryManager;

    // Sprites from the body part
    private SpriteResolver[] _sprites;

    // The slot image, will be changed if selected
    private Image _image;
    [SerializeField]
    private Color _selectedColor, _unselectedColor;

    // Gets the sell script from the button
    [SerializeField]
    private Sell _sellScript;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Select()
    {
        _image.color = _selectedColor;
    }

    public void Deselect()
    {
        _image.color = _unselectedColor;
    }

    public void ChangeCloth()
    {
        // Item in slot
        InventoryItem itemInSlot = GetComponentInChildren<InventoryItem>();
        


        if (itemInSlot != null)
        {
            // Will check the category, depending on the category it'll choose the correct body part
            switch (itemInSlot.item.category)
            {
                case Item.ItemCategory.Bodywear:
                    _correctBodyPart = _bodyParts[0];
                    break;

                case Item.ItemCategory.Footwear:
                    _correctBodyPart = _bodyParts[1];
                    break;

                // Takes the sprite renderer for the headgear obj
                case Item.ItemCategory.Headgear:
                    _correctBodyPart = _bodyParts[2];
                    break;

            }

        // Gets the sprite resolvers from the body part
        _sprites = _correctBodyPart.GetComponentsInChildren<SpriteResolver>();

        // The item's color
        var color = itemInSlot.item.color.ToString();

        // Changes character sprite by changing the category of the item + the color
        foreach (SpriteResolver sprite in _sprites)
        {
            // If the current player's color is equals to the item's color, then it'll reset back to default.
            // Otherwise, change to the item's color.
            // Also checks if it's wearing the item while selling it.
            // If it is then item's color will reset back to default
            if(sprite.GetLabel() == color) sprite.SetCategoryAndLabel(sprite.GetCategory(), "White");
            else if(!_sellScript.beingSold) sprite.SetCategoryAndLabel(sprite.GetCategory(), color);
        }

        }
    }

}

