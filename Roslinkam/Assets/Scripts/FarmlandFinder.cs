using System.Collections.Generic;
using UnityEngine;

public class FarmlandFinder : MonoBehaviour
{
    #region non public fields
    
    private List<Farmland> _farmlands = new List<Farmland>();
    
    #endregion

    #region public fields
    
    public List<Farmland> Farmlands => _farmlands;
    
    #endregion

    #region non public methods
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Farmland collisionFarmland = collision.GetComponent<Farmland>();
        if (collisionFarmland == null)
        {
            return;
        }
        _farmlands.Add(collisionFarmland);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Farmland collisionFarmland = collision.GetComponent<Farmland>();
        if (collisionFarmland == null || !_farmlands.Contains(collisionFarmland))
        {
            return;
        }
        _farmlands.Remove(collisionFarmland);
    }
    
    #endregion

    #region public methods
    
    public Farmland GetClosestEmptyFarmland()
    {
        Farmland result = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < _farmlands.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, _farmlands[i].transform.position);

            if (currentDistance < minDistance && _farmlands[i].IsEmpty)
            {
                minDistance = currentDistance;
                result = _farmlands[i];
            }
        }
        return result;
    }

    public Farmland GetClosestUnactiveFarmland()
    {
        return null;
    }

    #endregion
}
