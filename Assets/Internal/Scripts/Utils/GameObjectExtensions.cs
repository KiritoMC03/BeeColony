using UnityEngine;

namespace Utils
{
    public static class GameObjectExtensions
    {
        public static GameObject CreateEmpty(this GameObject gameObject)
        {
            return new GameObject();
        }
        
        public static T GetInterfaceComponent<T>(this GameObject gameObject)
            where T : class
        {
            return gameObject.GetComponent(typeof(T)) as T;
        }
        
        public static T GetSafeComponent<T>(this GameObject gameObject)
            where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if(component == null)
            {
                Debug.LogError("Expected to find component of type " + typeof(T) + " but found none.", gameObject);
            }
            return component;
        }
    }
}