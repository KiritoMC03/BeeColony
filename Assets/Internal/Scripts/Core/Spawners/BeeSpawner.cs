using UnityEngine;
using Utils;
using BeeColony.Core.Bees.Base;
using ObjectPool;

namespace BeeColony.Core.Spawners
{
    public class BeeSpawner : MonoBehaviourBase
    {
        [SerializeField] private BeeBase BeePrefab;

        public void Spawn()
        {
            ObjectPooler.Instance.GetObject(BeePrefab.Type);
        }
    }
}