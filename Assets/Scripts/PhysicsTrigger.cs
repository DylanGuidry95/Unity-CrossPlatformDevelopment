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
        public OnEnterTrigger onEnterTrigger;        
        private OnExitTrigger onExitTrigger;        
        private OnEnterCollision onEnterCollision;        
        private OnExitCollision onExitCollision;
#region AddEvents    
        public bool AddOnTriggerEnter()
        {            
            if (Events.Contains(onEnterTrigger))
            {                            
                return false;
            }
            onEnterTrigger = new OnEnterTrigger();
            Events.Add(onEnterTrigger);
            return true;
        }

        public bool AddOnTriggerExit()
        {
            if (Events.Contains(onExitTrigger))
            {                
                return false;
            }
            onExitTrigger = new OnExitTrigger();            
            Events.Add(onExitTrigger);
            return true;
        }

        public bool AddOnCollisionEnter()
        {
            if (Events.Contains(onEnterCollision))
            {                
                return false;
            }
            onEnterCollision = new OnEnterCollision();
            Events.Add(onEnterCollision);
            return true;
        }

        public bool AddOnCollisionExit()
        {
            if (Events.Contains(onExitCollision))
            {
                return false;
            }
            onExitCollision = new OnExitCollision();            
            Events.Add(onExitCollision);
            return true;
        }
        #endregion

#region RemoveEvents                   
        public void RemoveOnTriggerEnter()
        {
            if (!Events.Contains(onEnterTrigger)) return;
            Events.Remove(onEnterTrigger);
            onEnterTrigger = null;
        }

        public void RemoveOnTriggerExit()
        {
            if (!Events.Contains(onExitTrigger)) return;
            Events.Remove(onExitTrigger);
            onExitTrigger = null;
        }

        public void RemoveOnCollisionEnter()
        {
            if (!Events.Contains(onEnterCollision)) return;
            Events.Remove(onEnterCollision);
            onEnterCollision = null;
        }

        public void RemoveOnCollisionExit()
        {
            if (!Events.Contains(onExitCollision)) return;
            Events.Remove(onExitCollision);
            onExitCollision = null;
        }
#endregion
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
        public List<bool> DropDowns = new List<bool>();
        public List<string> EventNames = new List<string>();

        public List<string> ButtonText = new List<string>()
        {
            "AddOnEnterTrigger",
            "AddOnExitTrigger",
            "AddOnEnterCollision",
            "AddOnExitCollision"
        };
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var classRef = target as PhysicsTrigger;

            if (GUILayout.Button(ButtonText[0]))
            {
                if (classRef.AddOnTriggerEnter())
                {
                    DropDowns.Add(true);
                    EventNames.Add("OnEnterTrigger");
                    ButtonText[0] = "RemoveOnEnterTrigger";
                }
                else
                {
                    classRef.RemoveOnTriggerEnter();
                    ButtonText[0] = "AddOnEnterTrigger";
                    DropDowns.RemoveAt(EventNames.IndexOf("OnEnterTrigger"));
                    EventNames.Remove("OnEnterTrigger");
                }
            }
            if (GUILayout.Button(ButtonText[1]))
            {
                if (classRef.AddOnTriggerExit())
                {
                    DropDowns.Add(true);
                    EventNames.Add("OnExitTrigger");
                    ButtonText[1] = "RemoveOnExitTrigger";
                }
                else
                {
                    classRef.RemoveOnTriggerEnter();
                    ButtonText[0] = "AddOnExitTrigger";
                    DropDowns.RemoveAt(EventNames.IndexOf("OnExitTrigger"));
                    EventNames.Remove("OnExitTrigger");
                }
            }
            if (GUILayout.Button(ButtonText[2]))
            {
                if (classRef.AddOnCollisionEnter())
                {
                    DropDowns.Add(true); 
                    EventNames.Add("OnEnterCollision");
                    ButtonText[2] = "RemoveOnEnterCollision";
                }
                else
                {
                    classRef.RemoveOnCollisionEnter();
                    ButtonText[2] = "AddOnEnterCollision";
                    DropDowns.RemoveAt(EventNames.IndexOf("OnEnterCollision"));
                    EventNames.Remove("OnEnterCollision");
                }
            }
            if (GUILayout.Button(ButtonText[3]))
            {
                if (classRef.AddOnCollisionExit())
                {
                    DropDowns.Add(true);
                    EventNames.Add("OnExitCollision");
                    ButtonText[2] = "RemoveOnExitCollision";
                }
                else
                {
                    classRef.RemoveOnCollisionExit();
                    DropDowns.Add(true);
                    EventNames.Add("OnExitCollision");
                    ButtonText[3] = "RemoveOnExitCollision"; 
                }
            }
            for (var i = 0; i < DropDowns.Count; i++)
            {
                DropDowns[i] = EditorGUILayout.Foldout(DropDowns[i], EventNames[i]);
                if (DropDowns[i])
                {
                    GUILayout.Label("Text");
                }
            }
        }
    }
#endif
}
