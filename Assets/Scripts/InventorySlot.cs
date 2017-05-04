using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSlot", menuName = "Inventory/ItemSlot", order = 1)]
public class InventorySlot : ScriptableObject
{
    public int Capactiy;
    public Item ItemInSlot;
    public int NumberInSlot;
            
    public bool AddItem(Item item)
    {
        if(ItemInSlot == null)
        {
            ItemInSlot = item;
            NumberInSlot++;
            return true;
        }
        if (ItemInSlot.Name == item.Name)
        {
            NumberInSlot++;
            return true;
        }
        return false;
    }
}
