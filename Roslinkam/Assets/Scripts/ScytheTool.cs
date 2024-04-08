public class ScytheTool : Item
{
    #region non public fields

    private FarmlandFinder _farmlandFinder;
    
    #endregion

    #region public fields
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

        if (farmland == null)
        {
            return;
        }

        farmland.ActiveFarmland();
    }
    
    #endregion
}
