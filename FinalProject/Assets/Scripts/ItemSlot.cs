using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;

    public void Setup(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
