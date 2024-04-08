using UnityEngine;

public class SwordTool: Item
{
    #region non public fields
    
    [SerializeField] 
    private int _damage;
    [SerializeField] 
    private PlayerComponentsContainer _playerComponentsContainer;

    private Item _item;
    
    #endregion

    #region public fields
    #endregion

    #region non public methods
    #endregion

    #region public methods
    
    public override void Use()
    {
         DealDamage(_playerComponentsContainer.PlayerTargetFinder.Target);
    }

    public void DealDamage(HealthController target)
    {
        if (target == null)
        {
            return;
        }
        target.GetDamage(_damage);
    }
    
    #endregion
}
