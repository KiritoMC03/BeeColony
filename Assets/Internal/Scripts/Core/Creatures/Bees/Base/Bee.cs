using System;
using BeeColony.Core.Buildings;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees
{
    public class Bee : MonoBehaviourBase, IPooledObject
    {
        public UnityEvent OnHiveSet;

        public ObjectPooler.ObjectInfo.ObjectType Type => type;
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type;

        [Header("Any Bee")]
        [SerializeField] protected BeeMotor motor;
        [SerializeField] protected Hive parentHive;

        [Header("Description")]
        [SerializeField] protected string name = "Пчела";
        [SerializeField] protected SpriteRenderer spriteRenderer;

        protected Transform myTransform;
        protected Rigidbody2D myRigidbody;
        protected Collider2D myCollider;

        private void Awake()
        {
            myTransform = transform;
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
            OnCollisionEnter2D_Work(other);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter2D_Work(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExit2D_Work(other);
        }

        protected virtual void Awake_Work() {}
        protected virtual void OnEnable_Work() {}
        protected virtual void OnDisable_Work() {}
        protected virtual void FixedUpdate_Work() {}
        protected virtual void OnCollisionEnter2D_Work(Collision2D other) {}
        protected virtual void OnTriggerEnter2D_Work(Collider2D other) {}
        protected virtual void OnTriggerExit2D_Work(Collider2D other) {}

        internal virtual void SetParentHive(Hive hive)
        {
            parentHive = hive;
            OnHiveSet?.Invoke();
        }

        internal virtual void GoToParentHive(Hive hive)
        {
            motor.PhysicalMoveTo(hive.Position);
        }

        public string GetName()
        {
            return name;
        }

        public Sprite GetSprite()
        {
            return spriteRenderer.sprite;
        }
    }
}