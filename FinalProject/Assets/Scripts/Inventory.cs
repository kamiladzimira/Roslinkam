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

    List<Item> pickups = new List<Item>();

    private Item equipedItem;
    private ItemSlot selectedItemSlot;

    private void Start()
    {
        inventoryPanel.SetActive(false);
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
        if (pickups.Count >= itemSlots.Count)
        {
            return;
        }

        Item item = collision.GetComponent<Item>();

        if(pickups.Contains(item))
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
        Drop(selectedItemSlot.Item);
    }

    public void Equip(ItemSlot itemSlot)
    {
        if (itemSlot.Item == null)
        {
            return;
        }

        if (equipedItem != null)
        {
            equipedItem.gameObject.SetActive(false);
            equipedItem.transform.SetParent(itemContainer.transform);
        }

        itemSlot.Item.transform.SetParent(equipContainer.transform);
        itemSlot.Item.transform.localPosition = Vector3.zero;
        itemSlot.Item.gameObject.SetActive(true);
        equipedItem = itemSlot.Item;
        equipedItem.Equip(this);
    }

    public void Drop(Item item)
    {
        if (item == null)
        {
            return;
        }

        item.transform.position += Vector3.up * 2;
        item.transform.parent = null;
        item.gameObject.SetActive(true);
        pickups.Remove(item);
        equipedItem = null;
        SetupSlots();
    }

    private void SetupSlots()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            ItemSlot itemSlot = itemSlots[i];

            if (i < pickups.Count)
            {
                Item item = pickups[i];
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

        selectedItemSlot = null;
    }

    [ContextMenu("DropFirstItem")]
    private void DropFirstItem()
    {
        if(pickups.Count <= 0)
        {
            return;
        }
        Drop(pickups[0]);
    }
}
