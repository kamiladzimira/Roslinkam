using UnityEngine;

public class SwordTool: Item
{
    [SerializeField] private int damage;
    [SerializeField] PlayerComponentsContainer playerComponentsContainer;
    private Item item;

    public override void Use()
    {
         DealDamage(playerComponentsContainer.PlayerTargetFinder.Target);
    }

    public void DealDamage(HealthController target)
    {
        if (target == null)
        {
            return;
        }
        target.GetDamage(damage);
    }
}
