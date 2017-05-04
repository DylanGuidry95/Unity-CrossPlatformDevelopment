using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatKnife : MeleeWeapon
{
    public override void Equip(GameObject target)
    {
        base.Equip(target);
        Debug.Log(target.name + " lifts " + this.Name + "into the air");
    }
}
