using System.Collections.Generic;
using System;

[Serializable]
public class ItemContainer
{
    private List<Item> items;

    public IReadOnlyList<Item> Items => items;

    public ItemContainer(Item item)
    {
        items = new List<Item>();
        items.Add(item);
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
