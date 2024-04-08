using UnityEngine;
using TMPro;

public class FarmlandView : MonoBehaviour
{
    [SerializeField] private Farmland farmland;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] public SpriteRenderer seedRenderer;

    private void OnEnable()
    {
        farmland.onTimerChangedAction += OnTimerChanged;
        farmland.onPlantSeededAction += OnPlantSeeded;
    }

    private void OnDisable()
    {
        farmland.onTimerChangedAction -= OnTimerChanged;
        farmland.onPlantSeededAction -= OnPlantSeeded;
    }

    private void OnTimerChanged(float timerValue)
    {
        if(timerValue <= 0)
        {
            timerValue = 0;
            timer.gameObject.SetActive(false);
            seedRenderer.sprite = null;
        }
        timer.text = timerValue.ToString("0.00");
    }

    private void OnPlantSeeded()
    {
        timer.gameObject.SetActive(true);
        seedRenderer.sprite = farmland.Seed.Sprite;
    }
}
