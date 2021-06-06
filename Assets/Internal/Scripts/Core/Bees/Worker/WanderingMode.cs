using System;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColony.Core.Bees.Worker
{
    public class WanderingMode : MonoBehaviourBase
    {
        [SerializeField] private float radius = 3f;
        private Vector2 _target;
        
        public Vector2 GetNextPosition(Vector2 currentPosition)
        {
            if (CheckForTargetReaching(currentPosition))
            {
                _target = currentPosition + Random.insideUnitCircle * radius;
            }

            return _target;
        }

        private bool CheckForTargetReaching(Vector2 currentPosition)
        {
            return Math.Abs(currentPosition.x - _target.x) < 0.05f ||
                   Math.Abs(currentPosition.y - _target.y) < 0.1f;
        }
    }
}