using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item")]  
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public ItemCategory category;
    public ItemColor color;
    public float startingPrice;

    public enum ItemCategory
    {
        Headgear,
        Bodywear,
        Footwear
    }

    public enum ItemColor
    {
        White,
        Red
    }

}
