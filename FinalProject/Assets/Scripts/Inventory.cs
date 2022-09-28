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

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickups.Count >= itemSlots.Count)
        {
            return;
        }

        Item item = collision.GetComponent<Item>();

        if (item != null)
        {
            pickups.Add(item);
            item.gameObject.SetActive(false);
            item.transform.parent = itemContainer.transform;
            SetupSlots();
        }
    }

    public void Equip(ItemSlot itemSlot)
    {

        if (equipedItem != null)
        {
            equipedItem.gameObject.SetActive(false);
            equipedItem.transform.parent = itemContainer.transform;
        }

        itemSlot.Item.transform.SetParent(equipContainer.transform);
        itemSlot.Item.transform.localPosition = Vector3.zero;
        itemSlot.Item.gameObject.SetActive(true);
        equipedItem = itemSlot.Item;
    }

    public void Equip(Item item)
    {
        Debug.Log("click click item");
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
    }

    [ContextMenu("DropFirstItem")]
    private void DropFirstItem()
    {
        if (pickups.Count <= 0)
        {
            return;
        }
        Item itemToDrop = pickups[0];
        itemToDrop.transform.position += Vector3.right * 2;
        itemToDrop.transform.SetParent(null);
        itemToDrop.gameObject.SetActive(true);
        pickups.RemoveAt(0);
        SetupSlots();
    }



}
