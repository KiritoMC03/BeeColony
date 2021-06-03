﻿using BeeColony.Core.Bees.Base;
using ObjectPool;
using UnityEngine;

namespace BeeColony.Core.Bees.Worker
{
    public class WorkerBee : Bee
    {
        public ObjectPooler.ObjectInfo.BeeType Type { get; }

        [SerializeField] protected BeeResourceHandler resourceHandler;
        [SerializeField] protected BeeResourceRadar resourceRadar;
        [SerializeField] protected GameObject pollenEffect;

        protected override void OnEnable_Work()
        {
            resourceHandler.OnStorageChange.AddListener(ChangePoolerEffect);
            resourceHandler.OnDevastated.AddListener(resourceRadar.EnableRadar);
            resourceHandler.OnReplenished.AddListener(resourceRadar.DisableRadar);
        }
        
        protected override void OnDisable_Work()
        {
            resourceHandler.OnStorageChange.RemoveAllListeners();
            resourceHandler.OnDevastated.RemoveAllListeners();
            resourceHandler.OnReplenished.RemoveAllListeners();
        }

        private void ChangePoolerEffect()
        {
            pollenEffect.SetActive(!resourceHandler.IsStorageEmpty);
        }

        protected override void FixedUpdate_Work()
        {
            if (!resourceHandler.InProcessOfCollecting && resourceRadar.IsResourceSourceCached && resourceHandler.IsStorageEmpty)
            {
                GoToResourceSource(resourceRadar.ResourceSource);
                myCollider.enabled = true;
            }
            else if (!resourceHandler.IsStorageEmpty)
            {
                GoToParentHive(parentHive);
                myCollider.enabled = false;
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
            motor.PhysicalMoveTo(hive.Position);
        }

        internal void SetParentHive(Hive hive)
        {
            parentHive = hive;
        }
    }
}