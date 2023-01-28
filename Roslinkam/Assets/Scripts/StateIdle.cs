using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class StateIdle : IEnemyState
{
    //[SerializeField] private Animator animator;
    //private HealthController target;
    EnemyComponentsContainer enemyComponentsContainer;

    public StateIdle(EnemyComponentsContainer enemyComponentsContainer)
    {
        this.enemyComponentsContainer = enemyComponentsContainer;
    }

    public IEnemyState DoState()
    {
        Debug.Log("jestem w stanie idle");
        Debug.Log("wchodzê do stanu trigger");
        return enemyComponentsContainer.EnemyController.StateTrigger;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.GetComponent<HealthController>();
        //float distance = Vector2.Distance(target.transform.position, gameObject.transform.position);
        Debug.Log(distance);
        if (target == null)
        {
            animator.SetTrigger("Walk");
        }
        
    }*/
    // TODO:
    // jezeli playera nie ma w poblizu to enemy bedzie chodzil od punktu do punktu
    // jezeli player wyjdzie z collidera enemy to stan powinien powrocic znow do idle 
}
