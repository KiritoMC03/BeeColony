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
        //[SerializeField] private List<ObjectPooler.ObjectInfo.BeeType> beeTypes;
        
        /*
         [SerializeField] private ObjectPooler.ObjectInfo.BeeType beeType = 
            ObjectPooler.ObjectInfo.BeeType.Worker;
        */
        [SerializeField] private Hive fromHive;

        private void Awake()
        {
            if (fromHive == null)
            {
                throw new NullReferenceException("Hive is null.");
            }
        }
/*
        public void Spawn()
        {
            for (int i = 0; i < beeTypes.Count; i++)
            {
                var bee = ObjectPooler.Instance.GetObject(beeTypes[i]).GetComponent<Bee>();
                bee.SetParentHive(fromHive);
            }
        }
        */

        private void Start()
        {
            for (int i = 0; i < 0; i++)
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