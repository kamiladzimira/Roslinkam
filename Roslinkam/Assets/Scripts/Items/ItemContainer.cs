using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class ItemContainer
{
    #region non public fields

    [SerializeField] 
    private List<Item> _items;
    
    #endregion

    #region public fields

    public IReadOnlyList<Item> Items => _items;
    
    #endregion

    #region non public methods
    #endregion

    #region public methods

    public ItemContainer(Item item)
    {
        _items = new List<Item>();
        _items.Add(item);
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

    #endregion
}
