using System;
using UnityEngine;

namespace Utils
{
    public static class Lerp
    {
        public static Vector2 Variant(Vector2 start, Vector2 end, float t)
        {
            return start + (end - start) * t;
        }
    }
}