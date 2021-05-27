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
    }
}