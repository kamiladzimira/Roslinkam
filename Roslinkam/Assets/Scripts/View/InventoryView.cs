using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private List<ItemSlot> itemSlots;
    private ItemSlot selectedItemSlot;

    public void Select(ItemSlot itemSlot)
    {
        if (itemSlot.ItemContainer == null)
        {
            return;
        }
        selectedItemSlot = itemSlot;
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot == selectedItemSlot)
            {
                slot.Select(true);
            }
            else
            {
                slot.Select(false);
            }
        }
    }

    public void EquipSelectedItem()
    {
        if (selectedItemSlot == null)
        {
            return;
        }

        inventory.Equip(selectedItemSlot);
    }

    public void DropSelectedItem()
    {
        if (selectedItemSlot == null)
        {
            return;
        }
        inventory.Drop(selectedItemSlot.ItemContainer);
    }

    public void SetupSlots(List<ItemContainer> itemContainers)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            ItemSlot itemSlot = itemSlots[i];

            if (i < itemContainers.Count)
            {
                ItemContainer itemContainer = itemContainers[i];
                itemSlot.Setup(itemContainer);
            }
            else
            {
                itemSlot.Setup();
            }
        }

        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].Select(false);
        }

        selectedItemSlot = null;
    }
}

