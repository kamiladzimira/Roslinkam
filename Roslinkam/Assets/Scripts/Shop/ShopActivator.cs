using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopActivator : MonoBehaviour
{
    [SerializeField]
    PlayerComponentsContainer playerComponentsContainer;

    private List<Shop> shopItems = new List<Shop>();
    private Shop openShop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shop collisionShop = collision.GetComponent<Shop>();
        if (collisionShop == null)
        {
            return;
        }

        shopItems.Add(collisionShop);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Shop collisionShop = collision.GetComponent<Shop>();
        if (collisionShop == null || !shopItems.Contains(collisionShop))
        {
            return;
        }
        shopItems.Remove(collisionShop);
    }

    public void OnShopOpen(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        if (openShop != null)
        {
            openShop.TriggerShop(playerComponentsContainer);
            openShop = null;
            return;
        }

        if (shopItems.Count <= 0)
        {
            return;
        }

        openShop = GetClosestShop();
        openShop.TriggerShop(playerComponentsContainer);
    }

    private Shop GetClosestShop()
    {
        Shop result = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < shopItems.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, shopItems[i].transform.position);

            if (currentDistance < minDistance && shopItems[i].IsEmpty)
            {
                minDistance = currentDistance;
                result = shopItems[i];
            }
        }
        return result;
    }
}