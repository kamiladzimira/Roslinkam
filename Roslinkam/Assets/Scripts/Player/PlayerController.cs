using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private HealthController healthController;

    private void Start()
    {
        GameManager.GetInstance().RegisterPlayer(healthController);
    }
}
