using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    public static InventoryUICreationEvent CreateUI = new InventoryUICreationEvent();
}

public class InventoryUIEvent : UnityEvent<string>
{ }


public class InventoryUICreationEvent : UnityEvent<int>
{ }