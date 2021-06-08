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
    }
}