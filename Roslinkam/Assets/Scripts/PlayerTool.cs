using UnityEngine;

public class PlayerTool: Item
{
    [SerializeField] private int damage;
    [SerializeField] PlayerComponentsContainer playerComponentsContainer;
    private Item item;

    public override void Use()
    {
         DealDamage(playerComponentsContainer.PlayerTargetFinder.Target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerComponentsContainer.Inventory.AddItem(item);
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
