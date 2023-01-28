using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger : IEnemyState
{
    EnemyComponentsContainer enemyComponentsContainer;

    public StateTrigger(EnemyComponentsContainer enemyComponentsContainer)
    {
        this.enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        Debug.Log("jestem w stanie trigger");
        Debug.Log("wchodzê do stanu attack");
        return enemyComponentsContainer.EnemyController.StateAttack;
    }

    // TODO:
    // jezeli player wejdzie w collider enemiesa to enemy odtworzy animacje trigger i zacznie isc w strone playera
    // jezeli player odejdzie od enemy to ten ciagle bedzie szedl w jego strone, dopoki player nie wyjdzie z collidera
}
