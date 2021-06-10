using System;
using ObjectPool;
using UnityEngine;
using PooledObjectType = ObjectPool.ObjectPooler.ObjectInfo.ObjectType;
using Utils;

namespace Internal.Scripts.Core.Creatures.Enemies
{
    public class Enemy : MonoBehaviourBase, IPooledObject
    {
        public PooledObjectType Type => type;
        [SerializeField] private PooledObjectType type = PooledObjectType.Bear;

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

        protected virtual void FixedUpdate_Work() {}

        protected virtual void Start_Work() {}
        
    }
}