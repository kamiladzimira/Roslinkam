using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopInventoryPanel;
    [SerializeField] private GameObject playerInventoryPanel;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private List<ItemSlot> playerItemSlots;
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
                itemSlot.Setup(buyableItemsContainers[i]);
            }
            else
            {
                itemSlot.Setup();
            }
        }

        /*for (int _currentMonsterIndex = 0; _currentMonsterIndex < itemSlots.Count; _currentMonsterIndex++)
        {
            itemSlots[_currentMonsterIndex].Select(false);
        }*/
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

        /*for (int _currentMonsterIndex = 0; _currentMonsterIndex < playerItemSlots.Count; _currentMonsterIndex++)
        {

            playerItemSlots[_currentMonsterIndex].Select(false);
        }*/
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

    public void BuySelectedItemFromItemContainer()
    {
        if (activePlayerInventory.Money <= 0 || selectedItemSlot == null)
        {
            return;
        }

        ItemContainer itemContainer = selectedItemSlot.ItemContainer;
        Item itemToBuy = itemContainer.GetFirstItem();
        if (itemToBuy == null)
        {
            return;
        }
        if (activePlayerInventory.Money < itemToBuy.BuyPrice)
        {
            Debug.Log("You dont have enough money");
            return;
        }
        Debug.Log("You buy item for: " + itemToBuy.BuyPrice);
        RemoveFromBuyable(itemContainer, itemToBuy);

        activePlayerInventory.AddItem(itemToBuy);
        SetupPlayerSlots();
        SetupShopSlots();
        activePlayerInventory.ChangeMoneyValue(-(itemToBuy.BuyPrice));
    }

    private void RemoveFromBuyable(ItemContainer itemContainer, Item item)
    {
        itemContainer.RemoveItem(item);
        if (itemContainer.Items.Count <= 0)
        {
            buyableItemsContainers.Remove(itemContainer);
        }
    }

    public void SellSelectedItemFromItemContainer()
    {
        if (selectedItemSlot == null)
        {
            return;
        }

        ItemContainer itemContainer = selectedItemSlot.ItemContainer;
        Item itemToSell = itemContainer.GetFirstItem();
        if (  activePlayerInventory.ItemContainers == null || itemToSell == null)
        {
            return;
        }
        Debug.Log("You sell item for: " + itemToSell.SellPrice);
        activePlayerInventory.ChangeMoneyValue(itemToSell.SellPrice);

        activePlayerInventory.RemoveItem(itemToSell);
        Destroy(itemToSell.gameObject);
        //List<Item> itemToRemove = new List<Item>();

        /*for (int _currentMonsterIndex = 0; _currentMonsterIndex < itemContainer.Items.Count; _currentMonsterIndex++)
        {
            itemToRemove.Add(itemContainer.Items[_currentMonsterIndex]);
            activePlayerInventory.ChangeMoneyValue(10);
        }

        for (int _currentMonsterIndex = 0; _currentMonsterIndex < itemToRemove.Count; _currentMonsterIndex++)
        {
            activePlayerInventory.RemoveItem(itemToRemove[_currentMonsterIndex]);
            Destroy(itemToRemove[_currentMonsterIndex].gameObject);
        }*/
        SetupPlayerSlots();
        SetupShopSlots();
    }
}
