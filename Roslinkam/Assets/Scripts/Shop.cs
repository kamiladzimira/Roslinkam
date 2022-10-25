using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopInventoryPanel;
    [SerializeField] private GameObject playerInventoryPanel;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private List<ItemSlot> playerItemSlots;
    [SerializeField] List<Item> buyableItems = new List<Item>();

    private Inventory activePlayerInventory;

    private bool isEmpty = true;
    public bool IsEmpty => isEmpty;
    
    private ItemSlot selectedItemSlot;

    void Start()
    {
        shopInventoryPanel.SetActive(false);
        playerInventoryPanel.SetActive(false);
    }

    public void TriggerShop(PlayerComponentsContainer playerComponentsContainer)
    {
        activePlayerInventory = playerComponentsContainer.Inventory;
        shopInventoryPanel.SetActive(!shopInventoryPanel.activeSelf);
        playerInventoryPanel.SetActive(!playerInventoryPanel.activeSelf);
        SetupShopSlots();
        SetupPlayerSlots();
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

    public void SetupPlayerSlots()
    {
        if(activePlayerInventory == null)
        {
            return;
        }

        for (int i = 0; i < playerItemSlots.Count; i++)
        {
            ItemSlot playerItemSlot = playerItemSlots[i];

            if (i < activePlayerInventory.Pickups.Count)
            {
                Item item = activePlayerInventory.Pickups[i];
                playerItemSlot.Setup(item);
            }
            else
            {
                playerItemSlot.Setup();
            }
        }

        for (int i = 0; i < playerItemSlots.Count; i++)
        {
            playerItemSlots[i].Select(false);
        }
    }

    public void SelectShopItem(ItemSlot itemSlot)
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

        foreach (ItemSlot slot in playerItemSlots)
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
        if (activePlayerInventory.Money == 0)
        {
            return;
        }

        if(!buyableItems.Contains(selectedItemSlot.Item))
        {
            return;
        }

        if (selectedItemSlot == null)
        {
            return;
        }

        Item item = selectedItemSlot.Item;
        buyableItems.Remove(item);
        activePlayerInventory.AddItem(item);
        SetupPlayerSlots();
        SetupShopSlots();
        activePlayerInventory.ChangeMoneyValue(-10);
    }

    public void SellSelectedItem()
    {
        if (selectedItemSlot == null)
        {
            return;
        }

        bool playerContainsSelectedItem = false;
        for (int i = 0; i < activePlayerInventory.Pickups.Count; i++)
        {
            if (activePlayerInventory.Pickups[i] == selectedItemSlot.Item)
            {
                playerContainsSelectedItem = true;
            }
        }
        if (!playerContainsSelectedItem)
        {
            return;
        }

        Item item = selectedItemSlot.Item;
        activePlayerInventory.RemoveItem(item);
        Destroy(item.gameObject);
        SetupPlayerSlots();
        activePlayerInventory.ChangeMoneyValue(10);
    }
}
