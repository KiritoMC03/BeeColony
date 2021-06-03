using System;
using BeeColony.Core.Bees.Base;
using UnityEngine;
using Utils;
using ObjectPool;

namespace BeeColony.Core.Spawners
{
    public class BeeSpawner : MonoBehaviourBase
    {
        [SerializeField] private ObjectPooler.ObjectInfo.BeeType beeType = 
            ObjectPooler.ObjectInfo.BeeType.Worker;
        [SerializeField] private Hive fromHive;

        private void Awake()
        {
            if (fromHive == null)
            {
                throw new NullReferenceException("Hive is null.");
            }
        }

        public void Spawn()
        {
            var bee = ObjectPooler.Instance.GetObject(beeType).GetComponent<Bee>();
            bee.SetParentHive(fromHive);
        }
        
        public void Spawn(ObjectPooler.ObjectInfo.BeeType beeType)
        {
            var bee = ObjectPooler.Instance.GetObject(beeType).GetComponent<Bee>();
            bee.SetParentHive(fromHive);
        }
    }
}