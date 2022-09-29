using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    protected Inventory inventory;

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

    public void Equip(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public abstract void Use();

}
