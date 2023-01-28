using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmland : MonoBehaviour
{
    private Seed seed;
    private float timer;
    private bool isEmpty = true;

    [SerializeField] public Action<float> onTimerChangedAction;
    [SerializeField] public Action onPlantSeededAction;

    public Seed Seed => seed;
    public bool IsEmpty => isEmpty;

    private void Update()
    {
        ProcessTimer();
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

    public void SeedPlant(Seed seed)
    {
        timer = seed.GrowingTime;
        this.seed = seed;
        isEmpty = false;
        onPlantSeededAction?.Invoke();
    }
}
