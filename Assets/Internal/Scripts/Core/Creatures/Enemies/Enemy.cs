using System;
using BeeColonyCore;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;
using PooledObjectType = ObjectPool.ObjectPooler.ObjectInfo.ObjectType;
using Utils;

namespace Internal.Scripts.Core.Creatures.Enemies
{
    public class Enemy : MonoBehaviourBase, IPooledObject, IDamageable
    {
        public UnityEvent OnHealthChange;
        
        public PooledObjectType Type => type;
        [SerializeField] private PooledObjectType type = PooledObjectType.Bear;
        
        [SerializeField] private int health = 10;

        public Transform MyTransform { get; private set; }
        public Vector3 Position => MyTransform.position; 

        private void Awake()
        {
            MyTransform = transform;
        }

        private void Start()
        {
            Start_Work();
        }

        private void FixedUpdate()
        {
            FixedUpdate_Work();
        }

        public virtual void AcceptDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            OnHealthChange?.Invoke();
        }

        protected virtual void FixedUpdate_Work() {}

        protected virtual void Start_Work() {}
        
    }
}