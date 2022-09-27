using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Sprite Sprite => sprite;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        spriteRenderer.sprite = sprite;
    }
}
