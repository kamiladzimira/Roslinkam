using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image selectedImage;
    [SerializeField] TextMeshProUGUI amountOfItems;

    private Item item;
    private ItemContainer itemContainer;
    public Item Item => item;
    public ItemContainer ItemContainer => itemContainer;

    private void Start()
    {
        SetupAmountOfItems();
    }

    public void Select(bool isSelected)
    {
        selectedImage.gameObject.SetActive(isSelected);
    }

    public void SetupAmountOfItems()
    {
        amountOfItems.text = "";
    }

    public void Setup(Item item)
    {
        if (item == null)
        {
            Setup();
            return;
        }

        image.sprite = item.Sprite;
        image.gameObject.SetActive(true);
        this.item = item;
    }

    public void Setup(ItemContainer itemContainer)
    {
        Item item = itemContainer.GetFirstItem();

        if (item == null)
        {
            Setup();
            return;
        }

        image.sprite = item.Sprite;
        image.gameObject.SetActive(true);
        this.itemContainer = itemContainer;
        amountOfItems.text = itemContainer.Items.Count.ToString();
    }

    public void Setup()
    {
        image.sprite = null;
        image.gameObject.SetActive(false);
        item = null;
        SetupAmountOfItems();
    }
}
