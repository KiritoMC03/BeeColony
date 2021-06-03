using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColony.Core.Spawners
{
    public class ResourceSourcesSpawner : MonoBehaviourBase
    {
        [SerializeField] private float spawnRadius = 30f;
        [SerializeField] private ResourceSource resourceSource;

        private void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                var position = Random.insideUnitCircle * spawnRadius;

                var newSource = Instantiate(resourceSource);
                newSource.transform.position = position;
            }
        }
    }
}