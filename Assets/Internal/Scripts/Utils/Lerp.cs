using System;
using UnityEngine;

namespace Utils
{
    public static class Lerp
    {
        public static Vector2 Standart(Vector2 start, Vector2 end, float t)
        {
            return start + (end - start) * t;
        }
        
        public static Vector2 Sqrt(Vector2 start, Vector2 end, float t)
        {
            return start + (end - start) * Mathf.Pow(Mathf.Sqrt(Mathf.Sqrt(t)), 3);
        }
    }
}