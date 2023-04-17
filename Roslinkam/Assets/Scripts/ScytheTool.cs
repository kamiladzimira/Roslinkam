using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheTool : Item
{
    private FarmlandFinder farmlandFinder;

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

        if (farmland == null)
        {
            return;
        }

        farmland.ActiveFarmland();
    }
}
