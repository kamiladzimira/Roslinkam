using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] private List <Seed> seeds;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public Action<float> onTimerChangedAction;

    [SerializeField] float defaultTimer = 5f;
    private float timer;

    private Seed currentSeed;

    private void Start()
    {
        onTimerChangedAction?.Invoke(timer);
    }

    private void Update()
    {
        ProcessTimer();
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

        if (playerMovement == null || currentSeed != null || timer > 0)
        {
            return;
        }
        
        currentSeed = Instantiate(seeds[UnityEngine.Random.Range(0, seeds.Count)], spawnPoint.position, Quaternion.identity, null);
        timer = defaultTimer;
    }

    private void ProcessTimer()
    {
        if (timer <= 0)
        {
            return;
        }
        timer -= Time.deltaTime;
        onTimerChangedAction?.Invoke(timer);
    }
}
