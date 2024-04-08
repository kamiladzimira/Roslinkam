using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private Inventory _inventory;
    [SerializeField] 
    private List<ItemSlot> _itemSlots;

    private ItemSlot _selectedItemSlot;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods
    
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

    public void EquipSelectedItem()
    {
        if (_selectedItemSlot == null)
        {
            return;
        }

        _inventory.Equip(_selectedItemSlot);
    }

    public void DropSelectedItem()
    {
        if (_selectedItemSlot == null)
        {
            return;
        }
        _inventory.Drop(_selectedItemSlot.ItemContainer);
    }

    public void SetupSlots(List<ItemContainer> itemContainers)
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            ItemSlot itemSlot = _itemSlots[i];

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

        for (int i = 0; i < _itemSlots.Count; i++)
        {
            _itemSlots[i].Select(false);
        }

        _selectedItemSlot = null;
    }
    
    #endregion
}

