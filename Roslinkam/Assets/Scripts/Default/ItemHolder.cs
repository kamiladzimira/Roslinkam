using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private ItemPositionType _itemPositionType;

    #endregion

    #region public fields

    public ItemPositionType ItemPositionType => _itemPositionType;

    #endregion

    #region non public methods
    #endregion

    #region public methods
    #endregion
}
