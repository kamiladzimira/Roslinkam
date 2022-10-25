using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentsContainer : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Inventory inventory;

    public PlayerMovement PlayerMovement => playerMovement;
    public Inventory Inventory => inventory;
}
