using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    public static InventoryUICreationEvent CreateUI = new InventoryUICreationEvent();
    public static InventoryUIEvent ItemAdded = new InventoryUIEvent();
}

public class InventoryUIEvent : UnityEvent<string, int>
{ }


public class InventoryUICreationEvent : UnityEvent<int>
{ }