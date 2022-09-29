using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] private Seed seed;
    [SerializeField] private Transform spawnPoint;

    private Seed currentSeed;

    private void Awake()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePlayerTrigger(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Seed seed = collision.GetComponent<Seed>();
        if (seed != currentSeed)
        {
            return;
        }
        currentSeed = null;
    }

    private void HandlePlayerTrigger(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();

        if (playerMovement == null || currentSeed != null)
        {
            return;
        }
        currentSeed = Instantiate(seed, spawnPoint.position, Quaternion.identity, null);
    }
}
