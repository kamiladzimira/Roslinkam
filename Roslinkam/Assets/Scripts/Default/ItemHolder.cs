using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private ItemPositionType itemPositionType;

    public ItemPositionType ItemPositionType => itemPositionType;
}
