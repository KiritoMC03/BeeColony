using System;
using Unity.Mathematics;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColony.Core.Spawners
{
    public class ResourceSourcesSpawner : MonoBehaviourBase
    {
        [SerializeField] private float spawnRadius = 30f;
        [SerializeField] private ResourceSource resourceSource;
        private GameObject _emptyGameObject;

        private void Awake()
        {
            _emptyGameObject = new GameObject();
        }

        private void Start()
        {
            var container = Instantiate(_emptyGameObject);
            container.name = resourceSource.GetType().Name + "`s";
            container.isStatic = true;
            for (int i = 0; i < 100; i++)
            {
                var position = Random.insideUnitCircle * spawnRadius;

                Instantiate(resourceSource, position, quaternion.identity, container.transform);
            }
        }
    }
}