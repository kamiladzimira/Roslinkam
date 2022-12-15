using System.Collections.Generic;

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

    public void RemoveItem()
    {

    }
}
