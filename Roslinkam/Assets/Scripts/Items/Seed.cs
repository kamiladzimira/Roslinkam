using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    [SerializeField] private float growingTime;
    [SerializeField] private Item crop;
    private FarmlandFinder farmlandFinder;

    public float GrowingTime => growingTime;
    public Item Crop => crop;

    private void Start()
    {
        farmlandFinder = GetComponent<FarmlandFinder>();
    }

    public override void Use()
    {
        if (farmlandFinder.Farmlands.Count <= 0)
        {
            return;
        }

        Farmland farmland = farmlandFinder.GetClosestEmptyFarmland();

        if (farmland == null || !farmland.IsActive)
        {
            Debug.Log(farmland.IsActive);
            return;
        }

        inventory.Drop(this);
        inventory.Unequip();
        farmland.SeedPlant(this);
        gameObject.SetActive(false);
    }
}
