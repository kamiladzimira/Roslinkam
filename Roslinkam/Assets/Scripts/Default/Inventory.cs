using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private GameObject _inventoryPanel;
    [SerializeField]
    private List<ItemSlot> _itemSlots;
    [SerializeField]
    private GameObject _itemContainer;
    [SerializeField]
    private GameObject _equipContainer;
    [SerializeField]
    private List<ItemHolder> _equipedContainers;
    [SerializeField]
    private int _maxPickupsValue;
    [SerializeField]
    private List<InventoryView> _inventoryViews;

    private List<ItemContainer> _itemContainers = new List<ItemContainer>();
    private Item _equipedItem;
    private ItemSlot _selectedItemSlot;
    private int _money = 999;

    #endregion

    #region public fields

    public IReadOnlyList<ItemContainer> ItemContainers => _itemContainers;
    public int Money => _money;

    #endregion

    #region non public methods

    private void Start()
    {
        _inventoryPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        PickupItem(item);
    }

    private void PickupItem(Item item)
    {
        if (item == null)
        {
            return;
        }
        AudioManager.GetInstance().PlayPickUpSound();
        AddItem(item);
    }

    private void SetupSlots()
    {
        for (int i = 0; i < _inventoryViews.Count; i++)
        {
            _inventoryViews[i].SetupSlots(_itemContainers);
        }
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            ItemSlot itemSlot = _itemSlots[i];

            if (i < _itemContainers.Count)
            {
                ItemContainer itemContainer = _itemContainers[i];
                itemSlot.Setup(itemContainer);
            }
            else
            {
                itemSlot.Setup();
            }
        }
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            _itemSlots[i].Select(false);
        }
        _selectedItemSlot = null;
    }

    #endregion

    #region public methods

    public void ChangeMoneyValue(int value)
    {
        if (_money + value < 0)
        {
            return;
        }
        _money += value;
    }

    public void AddMoney(int value)
    {
        _money += value;
    }

    public void OnItemUse(InputAction.CallbackContext context)
    {
        if (_equipedItem == null)
        {
            return;
        }
        if (context.performed)
        {
            _equipedItem.Use();
        }
    }

    public void OnInventoryOpen(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
            SetupSlots();
        }
    }

    public void Select(ItemSlot itemSlot)
    {
        if (itemSlot.ItemContainer == null)
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
    }
    public void Equip(ItemSlot itemSlot)
    {
        if (itemSlot.ItemContainer == null)
        {
            return;
        }
        if (_equipedItem != null)
        {
            _equipedItem.gameObject.SetActive(false);
            _equipedItem.transform.SetParent(_itemContainer.transform);
            _equipedItem = null;
        }
        Item item = itemSlot.ItemContainer.GetFirstItem();
        ItemHolder itemHolder = GetItemHolder(item);
        if (item == null || itemHolder == null)
        {
            return;
        }
        item.transform.SetParent(itemHolder.transform);
        item.transform.localPosition = Vector3.zero;
        item.gameObject.SetActive(true);
        _equipedItem = item;
        _equipedItem.Equip(this);
    }

    public ItemHolder GetItemHolder(Item item)
    {
        if (item == null)
        {
            return null;
        }
        for (int i = 0; i < _equipedContainers.Count; i++)
        {
            if (_equipedContainers[i].ItemPositionType == item.ItemPositionType)
            {
                return _equipedContainers[i];
            }
        }
        return null;
    }

    public void Unequip()
    {
        if (_equipedItem == null)
        {
            return;
        }
        _equipedItem = null;
    }

    public void Drop(ItemContainer itemContainer)
    {
        if (itemContainer == null)
        {
            return;
        }
        for (int i = 0; i < itemContainer.Items.Count; i++)
        {
            itemContainer.Items[i].transform.position += Vector3.up * 2;
            itemContainer.Items[i].transform.parent = null;
            itemContainer.Items[i].gameObject.SetActive(true);
        }
        RemoveItem(itemContainer);
    }

    public void Drop(Item item)
    {
        if (_itemContainer == null)
        {
            return;
        }
        item.transform.position += Vector3.up * 2;
        item.transform.parent = null;
        item.gameObject.SetActive(true);
        RemoveItem(item);
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            bool foundContainer = false;
            for (int i = 0; i < _itemContainers.Count; i++)
            {
                if (_itemContainers[i].Items[0].ItemName == item.ItemName)
                {
                    _itemContainers[i].AddItem(item);
                    foundContainer = true;
                    SetupSlots();
                    break;
                }
            }
            if (_itemContainers.Count >= _maxPickupsValue)
            {
                return;
            }
            if (!foundContainer)
            {
                ItemContainer itemContainer = new ItemContainer(item);
                _itemContainers.Add(itemContainer);
                SetupSlots();
            }
            item.gameObject.SetActive(false);
            item.transform.SetParent(_itemContainer.transform);
        }
    }

    public void AddItem(InventoryItem inventoryItem)
    {
        if (inventoryItem != null)
        {
            bool foundContainer = false;
            for (int i = 0; i < _itemContainers.Count; i++)
            {
                if (_itemContainers[i].Items[0].ItemName == inventoryItem.GetIconName())
                {
                    _itemContainers[i].AddItem(inventoryItem);
                    foundContainer = true;
                    SetupSlots();
                    break;
                }
            }
            if (_itemContainers.Count >= _maxPickupsValue)
            {
                return;
            }
            if (!foundContainer)
            {
                ItemContainer itemContainer = new ItemContainer(inventoryItem);
                _itemContainers.Add(itemContainer);
                SetupSlots();
            }

            /*inventoryItem.SetActive(false);
            inventoryItem.transform.SetParent(_itemContainer.transform);*/
        }
    }

    public void RemoveItem(ItemContainer itemContainer)
    {
        if (!_itemContainers.Contains(itemContainer))
        {
            return;
        }
        _itemContainers.Remove(itemContainer);
        for (int i = 0; i < itemContainer.Items.Count; i++)
        {
            itemContainer.Items[i].transform.SetParent(null);
        }
        SetupSlots();
    }

    public void RemoveItem(Item item)
    {
        ItemContainer itemContainer = null;

        for (int i = 0; i < _itemContainers.Count; i++)
        {
            ItemContainer tempContainer = _itemContainers[i];
            for (int j = 0; j < tempContainer.Items.Count; j++)
            {
                if (tempContainer.Items[j] == item)
                {
                    itemContainer = tempContainer;
                }
            }
        }
        Debug.Log(itemContainer.Items.Count);
        if (itemContainer == null)
        {
            return;
        }
        itemContainer.RemoveItem(item);
        Debug.Log(itemContainer.Items.Count);
        item.transform.SetParent(null);
        if (itemContainer.Items.Count <= 0)
        {
            _itemContainers.Remove(itemContainer);

        }
        SetupSlots();
    }

    #endregion
}
