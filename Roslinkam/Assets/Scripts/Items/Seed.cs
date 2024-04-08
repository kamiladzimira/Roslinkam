using UnityEngine;

public class Seed : Item
{
    #region non public fields

    [SerializeField]
    private float _growingTime;
    [SerializeField]
    private Item _crop;

    private FarmlandFinder _farmlandFinder;

    #endregion

    #region public fields

    public float GrowingTime => _growingTime;
    public Item Crop => _crop;

    #endregion

    #region non public methods
    
    private void Start()
    {
        _farmlandFinder = GetComponent<FarmlandFinder>();
    }

    #endregion

    #region public methods

    public override void Use()
    {
        if (_farmlandFinder.Farmlands.Count <= 0)
        {
            return;
        }

        Farmland farmland = _farmlandFinder.GetClosestEmptyFarmland();

        if (farmland == null || !farmland.IsActive)
        {
            Debug.Log(farmland.IsActive);
            return;
        }

        _inventory.Drop(this);
        _inventory.Unequip();
        farmland.SeedPlant(this);
        gameObject.SetActive(false);
    }

    #endregion
}
