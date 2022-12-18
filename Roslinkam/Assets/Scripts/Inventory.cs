using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private GameObject equipContainer;
    [SerializeField] private int maxPickupsValue;

    [SerializeField] private List<InventoryView> inventoryViews;

    private List<Item> pickups = new List<Item>();

    private List<ItemContainer> itemContainers = new List<ItemContainer>();

    private Item equipedItem;
    private ItemSlot selectedItemSlot;

    private int money = 0;
    public IReadOnlyList<Item> Pickups => pickups;
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
        NewOnTriggerEnter2D(collision);
    }

    private void OldOnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (pickups.Contains(item) || pickups.Count >= maxPickupsValue)
        {
            return;
        }

        if (item != null)
        {
            pickups.Add(item);
            item.gameObject.SetActive(false);
            item.transform.SetParent(itemContainer.transform);
            SetupSlots();
        }
    }

    private void NewOnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item != null)
        {
            bool foundContainer = false;

            for (int i = 0; i < itemContainers.Count; i++)
            {
                if (itemContainers[i].Items[0].name == item.name)
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

        Equip(selectedItemSlot);
    }

    public void DropSelectedItem()
    {
        if (selectedItemSlot == null)
        {
            return;
        }
        Drop(selectedItemSlot.ItemContainer);
    }

    public void Equip(ItemSlot itemSlot)
    {
        if (itemSlot.ItemContainer == null)
        {
            return;
        }

        if (equipedItem != null)
        {
            equipedItem.gameObject.SetActive(false);
            equipedItem.transform.SetParent(itemContainer.transform);
        }

        Item item = itemSlot.ItemContainer.GetFirstItem();
        item.transform.SetParent(equipContainer.transform);
        //itemSlot.Item.transform.SetParent(equipContainer.transform);

        item.transform.localPosition = Vector3.zero;
        //itemSlot.Item.transform.localPosition = Vector3.zero;

        item.gameObject.SetActive(true);
        //itemSlot.Item.gameObject.SetActive(true);

        equipedItem = item;
        //equipedItem = itemSlot.Item;

        equipedItem.Equip(this);
    }

    public void Drop(ItemContainer itemContainer)
    {
        if (itemContainer == null)
        {
            return;
        }

        Item item = itemContainer.GetFirstItem();

        item.transform.position += Vector3.up * 2;
        //item.transform.position += Vector3.up * 2;

        item.transform.parent = null;
        //item.transform.parent = null;

        item.gameObject.SetActive(true);
        //item.gameObject.SetActive(true);

        equipedItem = null;
        RemoveItem(itemContainer);
    }

    public void AddItem(Item item)
    {
        if (pickups.Contains(item))
        {
            return;
        }
        if (item != null)
        {
            pickups.Add(item);
            item.gameObject.SetActive(false);
            item.transform.SetParent(itemContainer.transform);
            SetupSlots();
        }
    }

    public void RemoveItem(ItemContainer itemContainer)
    {
        if (!itemContainers.Contains(itemContainer))
        {
            return;
        }
        itemContainers.Remove(itemContainer);
        SetupSlots();
        itemContainer.Items[0].transform.SetParent(null);
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
                itemSlot.Setup();
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

    /*[ContextMenu("DropFirstItem")]
    private void DropFirstItem()
    {
        if(pickups.Count <= 0)
        {
            return;
        }
        Drop(pickups[0]);
    }*/
}
