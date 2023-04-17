using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmlandFinder : MonoBehaviour
{
    private List<Farmland> farmlands = new List<Farmland>();
    public List<Farmland> Farmlands => farmlands;

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

    public Farmland GetClosestEmptyFarmland()
    {
        Farmland result = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < farmlands.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, farmlands[i].transform.position);

            if (currentDistance < minDistance && farmlands[i].IsEmpty)
            {
                minDistance = currentDistance;
                result = farmlands[i];
            }
        }
        return result;
    }

    public Farmland GetClosestUnactiveFarmland()
    {
        return null;
    }
}
