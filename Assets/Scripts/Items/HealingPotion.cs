using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : Potion
{
    public int HealAmount;

    public override void Consume(GameObject target)
    {
        base.Consume(target);
        Debug.Log(target.name + " was healed for " + HealAmount);
        Destroy(this);
    }
}
