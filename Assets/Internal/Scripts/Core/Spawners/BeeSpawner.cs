using System;
using System.Collections;
using System.Collections.Generic;
using BeeColony.Core.Bees;
using BeeColony.Core.Buildings;
using UnityEngine;
using Utils;
using ObjectPool;

namespace BeeColony.Core.Spawners
{
    public class BeeSpawner : MonoBehaviourBase
    {
        [SerializeField] private Hive fromHive;
        [Range(0.05f, 1f)]
        [SerializeField] private float delay = 1f;

        [Header("Flight boundaries.")]
        [SerializeField] private Vector2 positiveBoundary;
        [SerializeField] private Vector2 negativeBoundary;

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
            bee.SetFlightBoundaries(positiveBoundary, negativeBoundary);
        }
    }
}