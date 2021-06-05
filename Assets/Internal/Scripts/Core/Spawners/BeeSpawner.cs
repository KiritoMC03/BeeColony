using System;
using System.Collections.Generic;
using BeeColony.Core.Bees.Base;
using UnityEngine;
using Utils;
using ObjectPool;

namespace BeeColony.Core.Spawners
{
    public class BeeSpawner : MonoBehaviourBase
    {
        [SerializeField] private Hive fromHive;

        private void Awake()
        {
            if (fromHive == null)
            {
                throw new NullReferenceException("Hive is null.");
            }
        }

        private void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                SpawnWorker();
            }
        }

        public void SpawnWorker()
        {
            Spawn(ObjectPooler.ObjectInfo.BeeType.Worker);
        }
        
        public void SpawnGuardian()
        {
            Spawn(ObjectPooler.ObjectInfo.BeeType.Guardian);
        } 

        private void Spawn(ObjectPooler.ObjectInfo.BeeType beeType)
        {
            var bee = ObjectPooler.Instance.GetObject(beeType).GetComponent<Bee>();
            bee.SetParentHive(fromHive);
        }
    }
}