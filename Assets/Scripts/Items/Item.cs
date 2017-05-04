using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IConsumable
{
    void Consume(GameObject target);
}

interface IEquipable
{
    void Equip(GameObject target);
}

[CreateAssetMenu(fileName = "Default", menuName = "Inventory/DefaultItem", order = 1)]
public class Item : ScriptableObject
{
    public string Name;
    public bool IsStackable;
}