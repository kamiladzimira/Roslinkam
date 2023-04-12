using UnityEngine;

public abstract class Item : MonoBehaviour, ISellable, IBuyable
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int price;
    [SerializeField] private string itemName;
    [SerializeField] private ItemPositionType itemPositionType;

    protected Inventory inventory;
    public Sprite Sprite => sprite;
    public int BuyPrice => price;
    public int SellPrice => price;
    public string ItemName => itemName;
    public ItemPositionType ItemPositionType => itemPositionType;

    public void Sell()
    {
        Debug.Log("Witaj swiecie");
    }

    public void Buy()
    {
        Debug.Log("Witaj swiecie");
    }

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
