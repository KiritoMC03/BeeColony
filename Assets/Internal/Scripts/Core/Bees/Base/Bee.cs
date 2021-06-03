using System;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class Bee : MonoBehaviourBase, IPooledObject
    {
        public UnityEvent OnHiveSet;
        
        public ObjectPooler.ObjectInfo.BeeType Type { get; }

        [SerializeField] protected BeeMotor motor;
        [SerializeField] protected BeeResourceRadar resourceRadar;
        [SerializeField] protected Hive parentHive;

        [SerializeField] protected float avoidForce = 10f;

        protected Rigidbody2D myRigidbody;
        protected Collider2D myCollider;

        private void Awake()
        {
            myRigidbody = GetSafeComponent<Rigidbody2D>();
            myCollider = GetSafeComponent<Collider2D>();
            Awake_Work();
        }

        private void OnEnable()
        {
            OnEnable_Work();
        }

        private void OnDisable()
        {
            OnDisable_Work();
        }

        private void FixedUpdate()
        {
            FixedUpdate_Work();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            ObstacleAvoidant.Avoid(myRigidbody, other.transform, avoidForce);
            OnCollisionEnter2D_Work(other);
        }

        protected virtual void Awake_Work() {}
        protected virtual void OnEnable_Work() {}
        protected virtual void OnDisable_Work() {}
        protected virtual void FixedUpdate_Work() {}
        protected virtual void OnCollisionEnter2D_Work(Collision2D other) {}

        internal virtual void SetParentHive(Hive hive)
        {
            parentHive = hive;
            OnHiveSet?.Invoke();
        }

        internal virtual void GoToParentHive(Hive hive)
        {
            motor.PhysicalMoveTo(hive.Position);
        }
    }
}