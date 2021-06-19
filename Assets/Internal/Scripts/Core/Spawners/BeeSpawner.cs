using System;
using System.Collections;
using System.Collections.Generic;
using BeeColonyCore.Bees;
using BeeColonyCore.Buildings;
using BeeColonyCore.Map;
using UnityEngine;
using Utils;
using ObjectPool;

namespace BeeColonyCore.Spawners
{
    public class BeeSpawner : MonoBehaviourBase
    {
        [SerializeField] private Hive fromHive;
        [Range(0.05f, 20f)]
        [SerializeField] private float delay = 1f;
        [SerializeField] private MapBoundaries boundaries;

        private Queue<ObjectPooler.ObjectInfo.ObjectType> _spawnQueue;

        private void Awake()
        {
            if (fromHive == null)
            {
                throw new NullReferenceException("Hive is null.");
            }

            _spawnQueue = new Queue<ObjectPooler.ObjectInfo.ObjectType>();
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnRoutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
        
        public IEnumerator SpawnRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                if (_spawnQueue.Count > 0)
                {
                    Spawn(_spawnQueue.Dequeue());
                }
            }
        }
        
        public void AddToSpawnQueue(Bee bee)
        {
            AddToSpawnQueue(bee.Type);
        }

        public void AddToSpawnQueue(ObjectPooler.ObjectInfo.ObjectType type)
        {
            _spawnQueue.Enqueue(type);
        }

        public void SpawnWorker()
        {
            _spawnQueue.Enqueue(ObjectPooler.ObjectInfo.ObjectType.Worker);
        }
        
        public void SpawnGuardian()
        {
            _spawnQueue.Enqueue(ObjectPooler.ObjectInfo.ObjectType.Guardian);
        } 

        private void Spawn(ObjectPooler.ObjectInfo.ObjectType objectType)
        {
            var bee = ObjectPooler.Instance.GetObject(objectType).GetComponent<Bee>();
            bee.SetParentHive(fromHive);
            bee.SetFlightBoundaries(boundaries.GetPositive(), boundaries.GetNegative());
        }

        public float GetDelay() => delay;
    }
}