using System;
using ObjectPool;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class Bee : MonoBehaviourBase, IPooledObject
    {
        public ObjectPooler.ObjectInfo.ObjectType Type { get; }

        [SerializeField] private BeeMotor motor;
        [SerializeField] private BeeRadar radar;
        [SerializeField] private BeeResourceHandler resourceHandler;
        [SerializeField] private Hive parentHive;
        [SerializeField] private GameObject pollenEffect;

        private void Start()
        {
            resourceHandler.StartListenStorageChange(ChangePoolerEffect);
        }

        private void ChangePoolerEffect()
        {
            Debug.Log("Change!");
            pollenEffect.SetActive(!resourceHandler.IsStorageEmpty);
        }

        private void FixedUpdate()
        {
            if (!resourceHandler.InProcessOfCollecting && radar.IsResourceSourceCached && resourceHandler.IsStorageEmpty)
            {
                GoToResourceSource(radar.ResourceSource);
            }
            else if (!resourceHandler.IsStorageEmpty)
            {
                GoToParentHive(parentHive);
            }
            else
            {
                motor.Stop();
            }
        }

        private void GoToResourceSource(ResourceSource source)
        {
            motor.PhysicalMoveTo(source.transform.position);
        }

        private void GoToParentHive(Hive hive)
        {
            motor.PhysicalMoveTo(hive.transform.position);
        }

        internal void SetParentHive(Hive hive)
        {
            parentHive = hive;
        }
    }
}