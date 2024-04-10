using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private Image _image;
    [SerializeField]
    private Image _selectedImage;
    [SerializeField]
    private TextMeshProUGUI _amountOfItems;

    private Item _item;
    private InventoryItem _inventoryItem;
    private ItemContainer _itemContainer;

    #endregion

    #region public fields

    public Item Item => _item;
    public InventoryItem InventoryItem => _inventoryItem;
    public ItemContainer ItemContainer => _itemContainer;

    #endregion

    #region non public methods

    private void Start()
    {
        Setup();
    }

    #endregion

    #region public methods

    public void Select(bool isSelected)
    {
        _selectedImage.gameObject.SetActive(isSelected);
    }

    public void Setup(Item item)
    {
        if (item == null)
        {
            Setup();
            return;
        }

        _image.sprite = item.Sprite;
        _image.gameObject.SetActive(true);
        this._item = item;
    }

    public void Setup(InventoryItem inventoryItem)
    {
        if (inventoryItem == null)
        {
            Setup();
            return;
        }

        _image.sprite = inventoryItem.GetSprite();
        _image.gameObject.SetActive(true);
        this._inventoryItem = inventoryItem;
    }

    public void Setup(ItemContainer itemContainer)
    {
        Item item = itemContainer.GetFirstItem();

        if (item == null)
        {
            Setup();
            return;
        }

        _image.sprite = item.Sprite;
        _image.gameObject.SetActive(true);
        this._itemContainer = itemContainer;
        _amountOfItems.text = itemContainer.Items.Count.ToString();
    }

    public void Setup()
    {
        _image.sprite = null;
        _image.gameObject.SetActive(false);
        _inventoryItem = null;
        _amountOfItems.text = "";
    }

    #endregion
}