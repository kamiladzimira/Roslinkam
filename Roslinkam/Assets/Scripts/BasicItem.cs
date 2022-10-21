using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : Item, ISellable, IBuyable
{
    public void Sell()
    {
        Debug.Log("Witaj swiecie");
    }

    public void Buy()
    {
        Debug.Log("Witaj swiecie");
    }

    public override void Use()
    {
        Debug.Log("Item was used!");
    }    
}