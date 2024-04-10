using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : ScriptableObject
{
    [SerializeField]
    [Tooltip("The name of the item to namable this item.")]
    private string _itemName;
    [SerializeField]
    [Tooltip("The UI icon to represent this item in the inventory.")]
    private Sprite _sprite;
    [SerializeField]
    [Tooltip("The price of the item.")]
    private int _price;
    [SerializeField]
    [Tooltip("Position in which player will be holding item")]
    private ItemPositionType _itemPositionType;
    [Tooltip("If true, multiple items of this type can be stacked in the same inventory slot.")]
    [SerializeField] 
    private bool stackable = false;

    public string GetIconName()
    {
        return _itemName;
    }

    public Sprite GetSprite()
    {
        return _sprite;
    }

    public int GetPrice()
    {
        return _price;
    }

    public ItemPositionType GetItemPositionType()
    {
        return _itemPositionType;
    }
}
