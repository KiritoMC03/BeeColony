using UnityEngine;

namespace Utils
{
    public static class GameObjectExtensions
    {
        public static T GetInterfaceComponent<T>(this GameObject gameObject)
            where T : class
        {
            return gameObject.GetComponent(typeof(T)) as T;
        }
    }
}