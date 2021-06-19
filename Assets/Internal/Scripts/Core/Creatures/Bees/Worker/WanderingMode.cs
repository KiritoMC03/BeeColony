using System;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColonyCore.Bees
{
    public class WanderingMode : MonoBehaviourBase
    {
        [SerializeField] private float radius = 3f;
        private Vector2 _target;
        private int _moveAttempt = 100;
        
        public Vector2 GetNextPosition(Vector2 currentPosition)
        {
            if (CheckForTargetReaching(currentPosition) || _moveAttempt <= 0)
            {
                _target = currentPosition + Random.insideUnitCircle * radius;
                _moveAttempt = 100;
            }

            _moveAttempt--;
            return _target;
        }

        private bool CheckForTargetReaching(Vector2 currentPosition)
        {
            return Math.Abs(currentPosition.x - _target.x) < 0.05f ||
                   Math.Abs(currentPosition.y - _target.y) < 0.1f;
        }
    }
}