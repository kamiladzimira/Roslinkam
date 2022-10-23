using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopInventoryPanel;
    [SerializeField] private GameObject playerInventoryPanel;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] List<Item> buyableItems = new List<Item>();

    private bool isEmpty = true;
    public bool IsEmpty => isEmpty;
    
    private ItemSlot selectedItemSlot;

    void Start()
    {
        shopInventoryPanel.SetActive(false);
        playerInventoryPanel.SetActive(false);
    }

    public void TriggerShop()
    {
        shopInventoryPanel.SetActive(!shopInventoryPanel.activeSelf);
        playerInventoryPanel.SetActive(!playerInventoryPanel.activeSelf);
        SetupShopSlots();
    }

    public void SetupShopSlots()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            ItemSlot itemSlot = itemSlots[i];

            if (i < buyableItems.Count)
            {
                Item item = buyableItems[i];
                itemSlot.Setup(item);
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
    }

    public void Select(ItemSlot itemSlot)
    {
        if (itemSlot.Item == null)
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

    public void BuySelectedItem()
    {
        if (selectedItemSlot == null)
        {
            return;
        }
        Drop(selectedItemSlot.Item);
    }

    public void Drop(Item item)
    {
        if (item == null)
        {
            return;
        }

        buyableItems.Remove(item);
        Destroy(item.gameObject);
        SetupShopSlots();
    }
}
