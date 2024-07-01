using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopActivator : MonoBehaviour
{
    #region non public fields
    
    [SerializeField]
    private PlayerComponentsContainer _playerComponentsContainer;

    private List<Shop> _shopItems = new List<Shop>();
    private Shop _openShop;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shop collisionShop = collision.GetComponent<Shop>();
        if (collisionShop == null)
        {
            return;
        }

        _shopItems.Add(collisionShop);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Shop collisionShop = collision.GetComponent<Shop>();
        if (collisionShop == null || !_shopItems.Contains(collisionShop))
        {
            return;
        }
        _shopItems.Remove(collisionShop);
    }

    private Shop GetClosestShop()
    {
        Shop result = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < _shopItems.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, _shopItems[i].transform.position);

            if (currentDistance < minDistance && _shopItems[i].IsEmpty)
            {
                minDistance = currentDistance;
                result = _shopItems[i];
            }
        }
        return result;
    }

    #endregion

    #region public methods

    public void OnShopOpen(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        if (_openShop != null)
        {
            _openShop.TriggerShop(_playerComponentsContainer);
            _openShop = null;
            return;
        }

        if (_shopItems.Count <= 0)
        {
            return;
        }

        _openShop = GetClosestShop();
        _openShop.TriggerShop(_playerComponentsContainer);
    }
    
    #endregion
}