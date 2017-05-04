using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    [ContextMenu("Healing Potion")]
    void AddHealingPotion()
    {
        var potion = ScriptableObject.CreateInstance(typeof(HealingPotion)) as HealingPotion;
        potion.Name = "Healing Potion";
        GetComponent<Inventory>().AddItem(potion);
    }

    [ContextMenu("Combat Knife")]
    void AddCombatKnife()
    {        
        var knife = ScriptableObject.CreateInstance(typeof(CombatKnife)) as CombatKnife;
        knife.Name = "Badass Knife";
        GetComponent<Inventory>().AddItem(knife);
    }
}
