using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopActivator : MonoBehaviour
{
    #region non public fields
    
    [SerializeField]
    private PlayerComponentsContainer _playerComponentsContainer;

    private List<Shop> _shopItems = new List<Shop>();
    private List<ShopSO> _shopSOItems = new List<ShopSO>();
    private ShopSO _openShop;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<ShopSO>(out ShopSO collisionShop))
        {
            return;
        }

        _shopSOItems.Add(collisionShop);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<ShopSO>(out ShopSO collisionShop) || !_shopSOItems.Contains(collisionShop))
        {
            return;
        }

        _shopSOItems.Remove(collisionShop);
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

    private ShopSO GetClosestSOShop()
    {
        ShopSO result = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < _shopSOItems.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, _shopSOItems[i].transform.position);

            if (currentDistance < minDistance && _shopSOItems[i].IsEmpty)
            {
                minDistance = currentDistance;
                result = _shopSOItems[i];
            }
        }
        Debug.Log($"result: {result}");
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

        if (_shopSOItems.Count <= 0)
        {
            return;
        }

        _openShop = GetClosestSOShop();
        _openShop.TriggerShop(_playerComponentsContainer);
    }
    
    #endregion
}