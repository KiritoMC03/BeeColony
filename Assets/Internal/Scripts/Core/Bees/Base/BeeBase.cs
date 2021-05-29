using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeBase : MonoBehaviourBase
    {
        [SerializeField] private SeenFlowersCache seenFlowersCache;
        [SerializeField] private BeeMotor motor;
        [SerializeField] private BeeResourceCollector resourceCollector;
        [SerializeField] private ParticleSystem pollen;

        private Flower _currentTargetFlower = null;
        private Vector3 _target;
        private bool _seeFlower = false;
        private float _waitTime = 2f;

        private void Awake()
        {
            seenFlowersCache.OnSeen.AddListener(ChangeCurrentTargetFlower);
        }

        private void FixedUpdate()
        {
            if (_seeFlower && !resourceCollector.IsCollected)
            {
                motor.MoveTo(_target);
            }
            else
            {
                motor.Stop();
            }
        }

        private void ChangeCurrentTargetFlower()
        {
            _currentTargetFlower = seenFlowersCache.ExtractFlower();
            seenFlowersCache.OnSeen?.RemoveAllListeners();
            
            _target = _currentTargetFlower.transform.position;
            _seeFlower = true;
        }
    }
}