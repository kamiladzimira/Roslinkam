using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;
    private Item item;
    public Item Item => item;

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

    public void Setup()
    {
        image.sprite = null;
        image.gameObject.SetActive(false);
        item = null;
    }
}
