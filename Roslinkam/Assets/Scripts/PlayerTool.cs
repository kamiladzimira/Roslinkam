using UnityEngine;

public class PlayerTool: Item
{
    [SerializeField] PlayerComponentsContainer playerComponentsContainer;
    private Item item;

    public override void Use()
    {
        Debug.Log("item was used");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerComponentsContainer.Inventory.AddItem(item);
    }
}
