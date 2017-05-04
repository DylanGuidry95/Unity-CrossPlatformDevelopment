using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> BagSlots;
    //public List<ItemSlot> EquipmentSlots;
    public int MaxSlots;

    [ContextMenu("CreateSlots")]
    void CreateItemSlots()
    {
        BagSlots = new List<InventorySlot>();
        for(int i = 0; i < MaxSlots; i++)
        {
            var newSlot = ScriptableObject.CreateInstance(typeof(InventorySlot)) as InventorySlot;
            BagSlots.Add(newSlot);
        }
        Events.CreateUI.Invoke(MaxSlots);
    }

    [ContextMenu("Add Item")]
    void AddItem()
    {
        var test = ScriptableObject.CreateInstance(typeof(Item)) as Item;
        test.name = "Testing";
        foreach(var slot in BagSlots)
        {
            if (slot.AddItem(test))
            {
                return;
            }
        }
    }
}
