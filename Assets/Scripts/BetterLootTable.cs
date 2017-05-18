using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "BetterLootTable", menuName = "LootTable/Better")]
public class BetterLootTable : ScriptableObject
{
    [System.Serializable]
    public class LootDropEvent : UnityEvent<List<Item>> { }

    [System.Serializable]
    public class DroppableItem
    {
        public Item Drop;
        [Range(0f,1f)]
        public float DropChance;
    }

    public List<DroppableItem> Drops = new List<DroppableItem>();
    public LootDropEvent lootDropEvent = new LootDropEvent();


    public void DropItems()
    {
        List<Item> DroppedItems= new List<Item>();
        float roll = Random.Range(0f, 1f);
        Debug.Log(roll);
        foreach (var item in Drops)
        {
            if(item.DropChance > roll)
                DroppedItems.Add(item.Drop);
        }

        //Testing
        foreach (var item in DroppedItems)
        {
            Debug.Log(item.DisplayName);
        }
        //End

        lootDropEvent.Invoke(DroppedItems);
    }    
}

#if UNITY_EDITOR
[CustomEditor((typeof(BetterLootTable)))]
public class InspectorBetterLootTable : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Drop Items"))
        {
            var refrence = target as BetterLootTable;
            refrence.DropItems();
        }
    }
}
#endif
