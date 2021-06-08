using System;
using System.Collections;
using BeeColony.Core.Bees.Base;
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
        [SerializeField] private float time = 0.1f;

        private void Awake()
        {
            if (fromHive == null)
            {
                throw new NullReferenceException("Hive is null.");
            }
        }

        private void Start()
        {

            StartCoroutine(SpawtRoutine());
            /*
            for (int i = 0; i < 100; i++)
            {
                SpawnWorker();
            }*/
        }
        
        public void Spawn(Bee bee)
        {
            Debug.Log($"Spawn: {bee.Type}");
            ObjectPooler.Instance.GetObject(bee.Type).GetComponent<Bee>().SetParentHive(fromHive);
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

        private IEnumerator SpawtRoutine()
        {
            for (int i = 0; i < 0; i++)
            {
                //Spawn(ObjectPooler.ObjectInfo.BeeType.Guardian);
                Spawn(ObjectPooler.ObjectInfo.BeeType.Worker);
                yield return new WaitForSeconds(time);
            }
        }
    }
}