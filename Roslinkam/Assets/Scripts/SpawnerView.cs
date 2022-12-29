using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerView : MonoBehaviour
{
    [SerializeField] private SeedSpawner seedSpawner;
    [SerializeField] TextMeshProUGUI timer;

    private void OnEnable()
    {
        seedSpawner.onTimerChangedAction += OnTimerChanged;
    }

    private void OnDisable()
    {
        seedSpawner.onTimerChangedAction -= OnTimerChanged;
    }

    private void OnTimerChanged(float timerValue)
    {
        if (timerValue <= 0)
        {
            //timerValue = 0;
            timer.text = "Ready!";
            return;
        }
        timer.text = timerValue.ToString("0.00");
    }
}
