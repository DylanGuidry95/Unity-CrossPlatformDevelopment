using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Physics
{
    public class PhysicsTrigger : MonoBehaviour
    {
        public List<UnityEvent<GameObject>> Events = new List<UnityEvent<GameObject>>();
        [SerializeField]
        private OnEnterTrigger onEnterTrigger;
        [SerializeField]
        private OnExitTrigger onExitTrigger;
        [SerializeField]
        private OnEnterCollision onEnterCollision;
        [SerializeField]
        private OnExitCollision onExitCollision;

        public void AddOnTriggerEnter()
        {
            if (Events.Contains(onEnterTrigger))
            {
                Debug.Log("Event all ready in list");
                return;
            }
            onEnterTrigger = new OnEnterTrigger();
            Events.Add(onEnterTrigger);
        }

        public void AddOnTriggerExit()
        {
            if (Events.Contains(onExitTrigger))
            {
                Debug.Log("Event all ready in list");
                return;
            }
            onExitTrigger = new OnExitTrigger();            
            Events.Add(onExitTrigger);
        }

        public void AddOnCollisionEnter()
        {
            if (Events.Contains(onEnterCollision))
            {
                Debug.Log("Event all ready in list");
                return;
            }
            onEnterCollision = new OnEnterCollision();
            Events.Add(onEnterCollision);
        }

        public void AddOnCollisionExit()
        {
            if (Events.Contains(onExitCollision))
            {
                Debug.Log("Event all ready in list");
                return;
            }
            onExitCollision = new OnExitCollision();
            onEnterCollision.AddListener(FindObjectOfType<SpikeyShield>().Block);
            Events.Add(onExitCollision);
        }
    }

    [Serializable]
    public class OnExitTrigger : UnityEvent<GameObject>
    {        
    }

    [Serializable]
    public class OnEnterTrigger : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class OnEnterCollision : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class OnExitCollision : UnityEvent<GameObject>
    {
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PhysicsTrigger))]
    class InspectorPhysicsTrigger : Editor
    {
        private List<bool> DropDowns;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var classRef = target as PhysicsTrigger;

            if (GUILayout.Button("OnEnterTrigger"))
            {
                classRef.AddOnTriggerEnter();
            }
            if (GUILayout.Button("OnExitTrigger"))
            {
                classRef.AddOnTriggerExit();
            }
            if (GUILayout.Button("OnEnterCollision"))
            {
                classRef.AddOnCollisionEnter();
            }
            if (GUILayout.Button("OnExitCollision"))
            {
                classRef.AddOnCollisionExit();
            }

            foreach (var physicEvent in classRef.Events)
            {
                GUILayout.Label(physicEvent.GetType().ToString());
            }
        }
    }
#endif
}
