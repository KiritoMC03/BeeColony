using UnityEngine;
using Utils;

namespace BeeColonyCore.Map
{
    public class MapBoundaries : MonoBehaviourBase
    {
        [SerializeField] private Vector2 positiveBoundary = new Vector2(-40f, 40f);
        [SerializeField] private Vector2 negativeBoundary = new Vector2(-40f, 40f);

        public Vector2 GetPositive() => positiveBoundary;
        public Vector2 GetNegative() => negativeBoundary;
    }
}