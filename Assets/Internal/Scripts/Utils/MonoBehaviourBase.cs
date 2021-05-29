using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class MonoBehaviourBase : MonoBehaviour
    {
        public I GetInterfaceComponent<I>()
            where I : class
        {
            return GetComponent(typeof(I)) as I;
        }

 
        public static List<I> FindObjectsOfInterface<I>()
            where I : class
        {
            var monoBehaviours = FindObjectsOfType<MonoBehaviour>();

            var componentsList = monoBehaviours.Select(behaviour => behaviour.GetComponent(typeof(I)));
            return componentsList.OfType<I>().ToList();
        }
        
        public T GetSafeComponent<T>()
            where T : Component
        {
            var component = GetComponent<T>();
            if(component == null)
            {
                Debug.LogError("Expected to find component of type " + typeof(T) + " but found none.", gameObject);
            }
            return component;
        }
    }
}