using System;
using ObjectPool;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class Bee : MonoBehaviourBase, IPooledObject
    {
        public ObjectPooler.ObjectInfo.ObjectType Type { get; }

        [SerializeField] private BeeMotor motor;
        [SerializeField] private BeeRadar radar;
        [SerializeField] private BeeResourceHandler resourceHandler;
        [SerializeField] private Hive parentHive;
        [SerializeField] private GameObject pollenEffect;

        [SerializeField] private float avoidForce = 10f;

        private Rigidbody2D _rigidbody;
        private Collider2D _collider;

        private void Awake()
        {
            _rigidbody = GetSafeComponent<Rigidbody2D>();
            _collider = GetSafeComponent<Collider2D>();
        }

        private void OnEnable()
        {
            resourceHandler.OnStorageChange.AddListener(ChangePoolerEffect);
            resourceHandler.OnDevastated.AddListener(radar.EnableRadar);
            resourceHandler.OnReplenished.AddListener(radar.DisableRadar);
        }

        private void ChangePoolerEffect()
        {
            pollenEffect.SetActive(!resourceHandler.IsStorageEmpty);
        }

        private void FixedUpdate()
        {
            if (!resourceHandler.InProcessOfCollecting && radar.IsResourceSourceCached && resourceHandler.IsStorageEmpty)
            {
                GoToResourceSource(radar.ResourceSource);
                _collider.enabled = true;
            }
            else if (!resourceHandler.IsStorageEmpty)
            {
                GoToParentHive(parentHive);
                _collider.enabled = false;
            }
            else
            {
                motor.Stop();
            }
        }

        private void GoToResourceSource(ResourceSource source)
        {
            motor.PhysicalMoveTo(source.transform.position);
        }
        private void GoToParentHive(Hive hive)
        {
            motor.PhysicalMoveTo(hive.Position);
        }

        internal void SetParentHive(Hive hive)
        {
            parentHive = hive;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            ObstacleAvoidant.Avoid(_rigidbody, other.transform, avoidForce);
        }

        private void OnDisable()
        {
            resourceHandler.OnStorageChange.RemoveAllListeners();
            resourceHandler.OnDevastated.RemoveAllListeners();
            resourceHandler.OnReplenished.RemoveAllListeners();
        }
    }
}