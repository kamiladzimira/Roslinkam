using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

[Serializable]
public class ItemContainer
{
    #region non public fields

    [SerializeField] 
    private List<Item> _items;

    [SerializeField]
    private List<InventoryItem> _inventoryItems;

    #endregion

    #region public fields

    public IReadOnlyList<Item> Items => _items;

    public IReadOnlyList<InventoryItem> InventoryItem => _inventoryItems;

    #endregion

    #region non public methods
    #endregion

    #region public methods

    public ItemContainer(Item item)
    {
        _items = new List<Item>();
        _items.Add(item);
    }

    public ItemContainer(InventoryItem inventoryItems)
    {
        _inventoryItems = new List<InventoryItem>();
        _inventoryItems.Add(inventoryItems);
    }

    public Item GetFirstItem()
    {
        if(_items.Count <= 0)
        {
            return null;
        }
        Item firstItem = _items[0];
        return firstItem;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (!_items.Contains(item))
        {
            return;
        }
        _items.Remove(item);
    }

    public InventoryItem GetFirstSOItem()
    {
        if (_inventoryItems.Count <= 0)
        {
            return null;
        }
        InventoryItem firstItem = _inventoryItems[0];
        return firstItem;
    }

    public void AddItem(InventoryItem inventoryItem)
    {
        _inventoryItems.Add(inventoryItem);
    }

    public void RemoveItem(InventoryItem inventoryItem)
    {
        if (!_inventoryItems.Contains(inventoryItem))
        {
            return;
        }
        _inventoryItems.Remove(inventoryItem);
    }

    #endregion
}
