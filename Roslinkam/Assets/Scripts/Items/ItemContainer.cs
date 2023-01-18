using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class ItemContainer
{
    [SerializeField] private List<Item> items;
    public IReadOnlyList<Item> Items => items;
    public ItemContainer(Item item)
    {
        items = new List<Item>();
        items.Add(item);
    }

    public Item GetFirstItem()
    {
        if(items.Count <= 0)
        {
            return null;
        }
        Item firstItem = items[0];
        return firstItem;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (!items.Contains(item))
        {
            return;
        }
        items.Remove(item);
    }
}