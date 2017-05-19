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
        public List<InspectorEventDisplay> InspectorEvents;
        private OnEnterTrigger onEnterTrigger;        
        private OnExitTrigger onExitTrigger;        
        private OnEnterCollision onEnterCollision;        
        private OnExitCollision onExitCollision;
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

    [Serializable]
    public class InspectorEventDisplay
    {
        [SerializeField]
        public UnityEvent<GameObject> _UnityEvent;        
        public InspectorEventDisplay(UnityEvent<GameObject> unityEvent)
        {
            _UnityEvent = unityEvent;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(InspectorEventDisplay))]
    class InspectorPhysicsTrigger : PropertyDrawer
    {
        public List<InspectorEventDisplay> InspectorEvents;

        public void OnGUI()
        {
            EditorGUI.BeginProperty(Rect.zero, GUIContent.none, null);
        }
    }
#endif
}
