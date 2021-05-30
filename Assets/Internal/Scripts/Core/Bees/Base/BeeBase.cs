using System;
using System.Collections;
using ObjectPool;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeBase : MonoBehaviourBase, IPooledObject
    {
        public ObjectPooler.ObjectInfo.ObjectType Type { get; }
        public Hive ParentHive { get; private set; } 
        
        [SerializeField] private SeenFlowerCache seenFlowerCache;
        [SerializeField] private BeeMotor motor;
        [SerializeField] private BeeResourceCollector resourceCollector;
        [SerializeField] private BeeResourceExtractor resourceExtractor;
        [SerializeField] private ParticleSystem pollen;

        public Flower _currentTargetFlower = null;
        private Vector3 _target;
        private bool _seeFlower = false;
        private float _waitTime = 2f;

        private void OnEnable()
        {
            StartListen();
        }
        
        private void OnDisable()
        {
            RemoveListeners();
        }

        private void FixedUpdate()
        {
            if (_seeFlower && !resourceCollector.InProcessOfCollecting)
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
            _currentTargetFlower = seenFlowerCache.GetLink();
            if (_currentTargetFlower == null)
            {
                _seeFlower = false;
                return;
            }
            
            seenFlowerCache.OnSeen.RemoveAllListeners();
            _target = _currentTargetFlower.transform.position;
            _seeFlower = true;
        }

        private void GoToHive()
        {
            try
            {
                _target = Hive.Instance.Position;
            }
            catch
            {
                throw new NullReferenceException("Hive not found or Hive.Instance is null.");
            }
        }

        private void FindNextFlower()
        {
            seenFlowerCache.OnSeen.RemoveAllListeners();
            StartListen();
            ChangeCurrentTargetFlower();
        }

        private void StartListen()
        {
            seenFlowerCache.OnSeen?.AddListener(ChangeCurrentTargetFlower);
            resourceCollector.OnCollected?.AddListener(GoToHive);
            resourceExtractor.OnExtracted?.AddListener(FindNextFlower);
        }

        private void RemoveListeners()
        {
            seenFlowerCache.OnSeen?.RemoveAllListeners();
            resourceCollector.OnCollected?.RemoveAllListeners();
            resourceExtractor.OnExtracted?.RemoveAllListeners();
        }
    }
}