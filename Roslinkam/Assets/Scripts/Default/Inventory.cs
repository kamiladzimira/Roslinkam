using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private GameObject equipContainer;

    [SerializeField] private List<ItemHolder> equipedContainers;
    [SerializeField] private int maxPickupsValue;
    [SerializeField] private List<InventoryView> inventoryViews;
    private List<ItemContainer> itemContainers = new List<ItemContainer>();
    private Item equipedItem;
    private ItemSlot selectedItemSlot;
    private int money = 999;
    public IReadOnlyList<ItemContainer> ItemContainers => itemContainers;
    public int Money => money;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void ChangeMoneyValue(int value)
    {
        if (money + value < 0)
        {
            return;
        }
        money += value;
    }

    public void AddMoney(int value)
    {
        money += value;
    }

    public void OnItemUse(InputAction.CallbackContext context)
    {
        if (equipedItem == null)
        {
            return;
        }
        if (context.performed)
        {
            equipedItem.Use();
        }
    }

    public void OnInventoryOpen(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            SetupSlots();
        }
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
    public void Equip(ItemSlot itemSlot)
    {
        if (itemSlot.ItemContainer == null)
        {
            return;
        }
        if (equipedItem != null )
        {
            equipedItem.gameObject.SetActive(false);
            equipedItem.transform.SetParent(itemContainer.transform);
            equipedItem = null;
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
        equipedItem = item;
        equipedItem.Equip(this);
    }

    public ItemHolder GetItemHolder(Item item)
    {
        if(item == null)
        {
            return null;
        }
        for (int i = 0; i < equipedContainers.Count; i++)
        {
            if (equipedContainers[i].ItemPositionType == item.ItemPositionType)
            {
                return equipedContainers[i];
            }
        }
        return null;
    }

    public void Unequip()
    {
        if (equipedItem == null)
        {
            return;
        }
        equipedItem = null;
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
        if (itemContainer == null)
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
            for (int i = 0; i < itemContainers.Count; i++)
            {
                if (itemContainers[i].Items[0].ItemName == item.ItemName)
                {
                    itemContainers[i].AddItem(item);
                    foundContainer = true;
                    SetupSlots();
                    break;
                }
            }
            if (itemContainers.Count >= maxPickupsValue)
            {
                return;
            }
            if (!foundContainer)
            {
                ItemContainer itemContainer = new ItemContainer(item);
                itemContainers.Add(itemContainer);
                SetupSlots();
            }
            item.gameObject.SetActive(false);
            item.transform.SetParent(itemContainer.transform);
        }
    }

    public void RemoveItem(ItemContainer itemContainer)
    {
        if (!itemContainers.Contains(itemContainer))
        {
            return;
        }
        itemContainers.Remove(itemContainer);
        for (int i = 0; i < itemContainer.Items.Count; i++)
        {
            itemContainer.Items[i].transform.SetParent(null);
        }
        SetupSlots();
    }

    public void RemoveItem(Item item)
    {
        ItemContainer itemContainer = null;

        for (int i = 0; i < itemContainers.Count; i++)
        {
            ItemContainer tempContainer = itemContainers[i];
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
            itemContainers.Remove(itemContainer);

        }
        SetupSlots();
    }

    private void SetupSlots()
    {
        for (int i = 0; i < inventoryViews.Count; i++)
        {
            inventoryViews[i].SetupSlots(itemContainers);
        }
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
