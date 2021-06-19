using System;
using System.Collections;
using BeeColonyCore.Bees;
using BeeColonyCore.Buildings;
using BeeColonyCore.Enemies;
using ObjectPool;
using UnityEngine;
using Utils;
using PooledObjectType = ObjectPool.ObjectPooler.ObjectInfo.ObjectType;

namespace BeeColonyCore.Spawners
{
    public class EnemiesSpawner : MonoBehaviourBase
    {
        [SerializeField] private Hive primaryHive;
        [SerializeField] private float distanceToMapEdge = 50f;
        
        [SerializeField] private Bear bear;
        [SerializeField] private uint count;
        [Range(0.05f, 1000f)]
        [SerializeField] private float period;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                Spawn(bear.Type);
                yield return new WaitForSeconds(period);
            }
        }

        private void Spawn(PooledObjectType objectType)
        {
            var bear = ObjectPooler.Instance.GetObject(objectType).GetComponent<Bear>();
            bear.SetPrimaryHive(primaryHive);
            bear.transform.position = PointGenerator.OnSquareBorder(distanceToMapEdge);
        }
    }
}