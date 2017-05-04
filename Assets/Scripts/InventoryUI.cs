﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject BagUI;
    public List<GameObject> BagSlots;

    private void Awake()
    {
        Events.CreateUI.AddListener(CreateInvetoryUISlots);
        Events.ItemAdded.AddListener(ModifySlotText);
    }

    void CreateInvetoryUISlots(int numslots)
    {
        for(int i = 0; i < numslots; i++)
        {
            var newSlot = Instantiate(Resources.Load("InventorySlot"))as GameObject;
            newSlot.transform.parent = BagUI.transform;
            BagSlots.Add(newSlot);
        }
    }

    void ModifySlotText(string newText, int index)
    {
        BagSlots[index].GetComponentInChildren<UnityEngine.UI.Text>().text = newText;
    }

    void SlotClicked(GameObject Slot)
    {
        Debug.Log(Slot.GetComponentInChildren<UnityEngine.UI.Text>().text);
    }
}
