using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Sprite Sprite => sprite;

    protected virtual void Awake()
    {
        Setup();
    }

    [ContextMenu("Setup")]
    protected virtual void Setup()
    {
        spriteRenderer.sprite = sprite;
    }

    public abstract void Use();
}
