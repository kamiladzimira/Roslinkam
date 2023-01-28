using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : IEnemyState
{
    EnemyComponentsContainer enemyComponentsContainer;

    public StateAttack(EnemyComponentsContainer enemyComponentsContainer)
    {
        this.enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        Debug.Log("jestem w stanie attack");
        Debug.Log("wchodzê do stanu idle");
        return enemyComponentsContainer.EnemyController.StateIdle;
    }

    // TODO:
    // jezeli enemy wejdzie w odpowiednia odleglosc od playera to zaczyna go atakowac
    // atakuje playera dopoki jego stan nie zmieni sie w trigger jezeli odleglosc pomiedzy enemy a graczem sie odpowiednio zwiekszy
    // albo zmieni sie w stan idle jezeli player zniknie np dzieki teleportacji
}
