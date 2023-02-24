using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentsContainer : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Inventory inventory;
    [SerializeField] private HealthController healthController;

    public PlayerMovement PlayerMovement => playerMovement;
    public Inventory Inventory => inventory;
    public HealthController HealthController => healthController;
}
