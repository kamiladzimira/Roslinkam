using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface ISellable
{
    public int SellPrice { get; }

    public void Sell();
}