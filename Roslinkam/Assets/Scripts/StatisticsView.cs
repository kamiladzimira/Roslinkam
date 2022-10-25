using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] PlayerComponentsContainer playerComponentsContainer;

    private void Update()
    {
        CoinsValueDispay();
    }
    public void CoinsValueDispay()
    {
        coins.text = playerComponentsContainer.Inventory.Money.ToString();
    }
}
