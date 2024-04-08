using UnityEngine;

public abstract class Item : MonoBehaviour, ISellable, IBuyable
{
    #region non public fields
    
    [SerializeField] 
    private Sprite _sprite;
    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    [SerializeField] 
    private int _price;
    [SerializeField] 
    private string _itemName;
    [SerializeField] 
    private ItemPositionType _itemPositionType;

    protected Inventory _inventory;
    
    #endregion

    #region public fields

    public Sprite Sprite => _sprite;
    public int BuyPrice => _price;
    public int SellPrice => _price;
    public string ItemName => _itemName;
    public ItemPositionType ItemPositionType => _itemPositionType;
    
    #endregion

    #region non public methods
    
    protected virtual void Awake()
    {
        Setup();
    }

    [ContextMenu("Setup")]
    protected virtual void Setup()
    {
        _spriteRenderer.sprite = _sprite;
    }

    public void Equip(Inventory inventory)
    {
        this._inventory = inventory;
    }

    public abstract void Use();
    
    #endregion

    #region public methods
    
    public void Sell()
    {
        Debug.Log("Witaj swiecie");
    }

    public void Buy()
    {
        Debug.Log("Witaj swiecie");
    }
    
    #endregion
}
