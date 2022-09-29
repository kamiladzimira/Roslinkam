using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    private List <Farmland> farmlands = new List<Farmland>();

    [SerializeField]private float growingTime;
    [SerializeField]private Item crop;

    public float GrowingTime => growingTime;
    public Item Crop => crop;
    public override void Use()
    {
        if (farmlands.Count <= 0)
        {
            return;
        }

        Farmland farmland = GetClosestEmptyFarmland();

        if (farmland == null)
        {
            return;
        }

        farmland.SeedPlant(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Farmland collisionFarmland = collision.GetComponent<Farmland>();
        if (collisionFarmland == null)
        {
            return;
        }

        farmlands.Add(collisionFarmland);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Farmland collisionFarmland = collision.GetComponent<Farmland>();
        if (collisionFarmland == null || !farmlands.Contains(collisionFarmland))
        {
            return;
        }
        farmlands.Remove(collisionFarmland);
    }

    private Farmland GetClosestEmptyFarmland()
    {
        Farmland result = null;
        float distance = float.MaxValue;

        for (int i = 0; i < farmlands.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, farmlands[i].transform.position);

            if (currentDistance < distance && farmlands[i].IsEmpty)
            {
                distance = currentDistance;
                result = farmlands[i];
            }
        }
        return result;
    }
}
