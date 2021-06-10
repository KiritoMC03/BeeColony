using UnityEngine;

namespace Utils
{
    public class PointGenerator : MonoBehaviourBase
    {
        public static Vector2 InCircle(float radius)
        {
            return Random.insideUnitCircle * radius;
        }
        
        public static Vector2 InRing(float smallRadius, float largeRadius)
        {
            var point = Random.insideUnitCircle;
            return (point.normalized * smallRadius) + (point * (largeRadius - smallRadius));
        }

        public static Vector2 InSquare(float a)
        {
            var x = Random.Range(-a, a);
            var y = Random.Range(-a, a);

            return new Vector2(x, y);
        }

        public static Vector2 OnSquareBorder(float a)
        {
            var random = new System.Random();
            if (Random.Range(-5f, 5f) < 0)
            {
                return new Vector2(random.PlusOrMinusOne() * a, Random.Range(-a, a));
            }
            return new Vector2(Random.Range(-a, a), random.PlusOrMinusOne() * a);
        }
    }
}