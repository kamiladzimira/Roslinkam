using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    
    [SerializeField] GameObject inventory;

    List<GameObject> pickups = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            pickups.Add(collision.gameObject);
            collision.gameObject.SetActive(false);
            collision.transform.parent = inventory.transform;
        }
    }
}
