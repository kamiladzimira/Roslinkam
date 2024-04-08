using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region non public fields

    [SerializeField] 
    private GameObject _shopInventoryPanel;
    [SerializeField] 
    private GameObject _playerInventoryPanel;
    [SerializeField] 
    private List<ItemSlot> _itemSlots;
    [SerializeField] 
    private List<ItemSlot> _playerItemSlots;
    [SerializeField] 
    private List<ItemContainer> _buyableItemsContainers = new List<ItemContainer>();
    private Inventory _activePlayerInventory;
    private bool _isEmpty = true;
    private ItemSlot _selectedItemSlot;
    
    #endregion

    #region public fields
    
    public bool IsEmpty => _isEmpty;

    #endregion

    #region non public methods

    private void Start()
    {
        _shopInventoryPanel.SetActive(false);
        _playerInventoryPanel.SetActive(false);
    }

    private void RemoveFromBuyable(ItemContainer itemContainer, Item item)
    {
        itemContainer.RemoveItem(item);
        if (itemContainer.Items.Count <= 0)
        {
            _buyableItemsContainers.Remove(itemContainer);
        }
    }

    #endregion

    #region public methods

    public void TriggerShop(PlayerComponentsContainer playerComponentsContainer)
    {
        _activePlayerInventory = playerComponentsContainer.Inventory;
        _shopInventoryPanel.SetActive(!_shopInventoryPanel.activeSelf);
        _playerInventoryPanel.SetActive(!_playerInventoryPanel.activeSelf);
        SetupShopSlots();
        SetupPlayerSlots();
    }

    public void SetupShopSlots()
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            ItemSlot itemSlot = _itemSlots[i];

            if (i < _buyableItemsContainers.Count)
            {
                itemSlot.Setup(_buyableItemsContainers[i]);
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
        if (_activePlayerInventory == null)
        {
            return;
        }

        for (int i = 0; i < _playerItemSlots.Count; i++)
        {
            ItemSlot playerItemSlot = _playerItemSlots[i];

            if (i < _activePlayerInventory.ItemContainers.Count)
            {
                playerItemSlot.Setup(_activePlayerInventory.ItemContainers[i]);
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

        _selectedItemSlot = itemSlot;

        foreach (ItemSlot slot in _itemSlots)
        {
            if (slot == _selectedItemSlot)
            {
                slot.Select(true);
            }
            else
            {
                slot.Select(false);
            }
        }

        foreach (ItemSlot slot in _playerItemSlots)
        {
            if (slot == _selectedItemSlot)
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
        if (_activePlayerInventory.Money <= 0 || _selectedItemSlot == null)
        {
            return;
        }

        ItemContainer itemContainer = _selectedItemSlot.ItemContainer;
        Item itemToBuy = itemContainer.GetFirstItem();
        if (itemToBuy == null)
        {
            return;
        }
        if (_activePlayerInventory.Money < itemToBuy.BuyPrice)
        {
            Debug.Log("You dont have enough money");
            return;
        }
        Debug.Log("You buy item for: " + itemToBuy.BuyPrice);
        RemoveFromBuyable(itemContainer, itemToBuy);

        _activePlayerInventory.AddItem(itemToBuy);
        SetupPlayerSlots();
        SetupShopSlots();
        _activePlayerInventory.ChangeMoneyValue(-(itemToBuy.BuyPrice));
    }

    

    public void SellSelectedItemFromItemContainer()
    {
        if (_selectedItemSlot == null)
        {
            return;
        }

        ItemContainer itemContainer = _selectedItemSlot.ItemContainer;
        Item itemToSell = itemContainer.GetFirstItem();
        if (  _activePlayerInventory.ItemContainers == null || itemToSell == null)
        {
            return;
        }
        Debug.Log("You sell item for: " + itemToSell.SellPrice);
        _activePlayerInventory.ChangeMoneyValue(itemToSell.SellPrice);

        _activePlayerInventory.RemoveItem(itemToSell);
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

    #endregion
}
