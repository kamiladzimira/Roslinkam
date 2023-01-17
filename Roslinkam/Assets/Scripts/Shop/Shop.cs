using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopInventoryPanel;
    [SerializeField] private GameObject playerInventoryPanel;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private List<ItemSlot> playerItemSlots;
    [SerializeField] List<Item> buyableItems = new List<Item>();

    [SerializeField] List<ItemContainer> buyableItemsContainers = new List<ItemContainer>();

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

            if (i < buyableItemsContainers.Count)
            {
                //Item item = buyableItems[i];
                itemSlot.Setup(buyableItemsContainers[i]);
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
        if (activePlayerInventory == null)
        {
            return;
        }

        for (int i = 0; i < playerItemSlots.Count; i++)
        {
            ItemSlot playerItemSlot = playerItemSlots[i];

            if (i < activePlayerInventory.ItemContainers.Count)
            {
                playerItemSlot.Setup(activePlayerInventory.ItemContainers[i]);
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
        if (itemSlot.Item == null && itemSlot.ItemContainer == null)
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
        if (activePlayerInventory.Money <= 0)
        {
            return;
        }

        if (!buyableItems.Contains(selectedItemSlot.Item))
        {
            return;
        }

        if (selectedItemSlot == null)
        {
            return;
        }

        Item item = selectedItemSlot.Item;

        if (activePlayerInventory.Money < item.BuyPrice)
        {
            Debug.Log("You dont have enough money");
            return;
        }

        buyableItems.Remove(item);
        activePlayerInventory.AddItem(item);
        SetupPlayerSlots();
        SetupShopSlots();
        activePlayerInventory.ChangeMoneyValue(-(item.BuyPrice));
    }

   /* public void SellSelectedItem()
    {
        if (selectedItemSlot == null)
        {
            return;
        }

        Item item = selectedItemSlot.Item;

        if (activePlayerInventory.ItemContainers == null)
        {
            return;
        }

        activePlayerInventory.RemoveItem(item);
        Destroy(item.gameObject);
        SetupPlayerSlots();
        activePlayerInventory.ChangeMoneyValue(10);
        SetupPlayerSlots();
        SetupShopSlots();
    }*/

    public void SellSelectedItemFromItemContainer()
    {
        if (selectedItemSlot == null)
        {
            return;
        }

        ItemContainer itemContainer = selectedItemSlot.ItemContainer;

        if (activePlayerInventory.ItemContainers == null)
        {
            return;
        }

        List<Item> itemToRemove = new List<Item>();

        for (int i = 0; i < itemContainer.Items.Count; i++)
        {
            itemToRemove.Add(itemContainer.Items[i]);
            activePlayerInventory.ChangeMoneyValue(10);
  
        }

        for (int i = 0; i < itemToRemove.Count; i++)
        {
            activePlayerInventory.RemoveItem(itemToRemove[i]);
            Destroy(itemToRemove[i].gameObject);
        }

        SetupPlayerSlots();
        SetupShopSlots();
    }
}
