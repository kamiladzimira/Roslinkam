using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New seed", menuName = "Seeds/Seed", order = 0)]
public class SeedSO : InventoryItem
{
    [SerializeField]
    [Tooltip("Only for seeds. Time after item will grow from seed")]
    private float _growingTime;
    [SerializeField]
    [Tooltip("Only for seeds. Item that will appear after grow time")]
    private ItemSO _crop;

    public float GetGrowingTime()
    {
        return _growingTime;
    }

    public ItemSO GetCrop()
    {
        return _crop;
    }
}
