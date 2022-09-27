using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject itemContainer;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] List<ItemSlot> itemSlots;

    List<Item> pickups = new List<Item>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
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

    public void Equip()
    {
        Debug.Log("click click");
    }

    private void SetupSlots()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        { 
            ItemSlot itemSlot = itemSlots[i];

            if (i < pickups.Count)
            {
                Item item = pickups[i];
                itemSlot.Setup(item.Sprite);
            }
            else
            {
                itemSlot.Setup(null);
            }
        }
    }

    [ContextMenu("DropFirstItem")]
    private void DropFirstItem()
    {
        if(pickups.Count <=0)
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
