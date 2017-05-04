using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> BagSlots;
    //public List<ItemSlot> EquipmentSlots;
    public int MaxSlots;

    private void Start()
    {
        CreateItemSlots();
    }

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
    public void AddItem(Item item)
    {
        foreach(var slot in BagSlots)
        {
            if (slot.AddItem(item))
            {
                Events.ItemAdded.Invoke(item.Name, BagSlots.IndexOf(slot));
                return;
            }
        }
    }
}
