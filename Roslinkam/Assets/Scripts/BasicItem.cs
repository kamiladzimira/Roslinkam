using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : Item
{
    public override void Use()
    {
        Debug.Log("Item was used!");
    }
}
