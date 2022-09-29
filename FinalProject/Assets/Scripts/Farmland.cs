using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Farmland : MonoBehaviour
{
    private Seed seed;
    private float timer;
    private bool isEmpty = true;

    [SerializeField] private SpriteRenderer seedRenderer;
    [SerializeField] public Action<float> onTimerChangedAction;

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
            isEmpty = true;
            Instantiate(seed.Crop, transform.position, Quaternion.identity, null);
            seedRenderer.sprite = null;
        }
    }

    public void SeedPlant(Seed seed)
    {
        timer = seed.GrowingTime;
        this.seed = seed;
        seedRenderer.sprite = this.seed.Sprite;
        isEmpty = false;
    }
}
