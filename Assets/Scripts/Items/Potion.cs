using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item, IConsumable
{
    public virtual void Consume(GameObject target)
    {
        Debug.Log(target.name + " consumed " + this.Name);
    }
}
