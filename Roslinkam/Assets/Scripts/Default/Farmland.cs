using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmland : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Seed seed;
    private float timer;
    private bool isEmpty = true;
    private bool isActive = false;

    public event Action<float> onTimerChangedAction;
    public event Action onPlantSeededAction;

    public Seed Seed => seed;
    public bool IsEmpty => isEmpty;
    public bool IsActive => isActive;

    private void Update()
    {
        ProcessTimer();
    }

    private void Start()
    {
        spriteRenderer.enabled = false;
    }

    private void ProcessTimer()
    {
        if (timer <= 0)
        {
            return;
        }
        timer -= Time.deltaTime;
        onTimerChangedAction?.Invoke(timer);
        if (timer <= 0)
        {
            Instantiate(seed.Crop, transform.position, Quaternion.identity, null);
            Destroy(seed.gameObject);
            isEmpty = true;
        }
    }

    public void ActiveFarmland()
    {
        if (!isActive)
        {
            spriteRenderer.enabled = true;
        }
        isActive = true;
    }

    public void SeedPlant(Seed seed)
    {
        if (isActive)
        {
            timer = seed.GrowingTime;
            this.seed = seed;
            isEmpty = false;
            onPlantSeededAction?.Invoke();
        }
    }
}
