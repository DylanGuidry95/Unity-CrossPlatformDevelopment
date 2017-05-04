using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Item, IEquipable
{
    public int HandRequired;

    public int Damage;

    public virtual void Equip(GameObject target)
    {
        Debug.Log(target.name + "Equiped" + this.Name);
    }    
}
