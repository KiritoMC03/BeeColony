using BeeColonyCore.Bees;
using BeeColonyCore.Buildings;
using ObjectPool;
using UnityEngine;

namespace BeeColonyCore.Bees
{
    public class WorkerBee : Bee
    {
        public ObjectPooler.ObjectInfo.ObjectType Type { get; }

        [Header("Worker Bee")]
        [SerializeField] protected BeeResourceHandler resourceHandler;
        [SerializeField] protected BeeResourceRadar resourceRadar;
        [SerializeField] protected GameObject pollenEffect;
        [SerializeField] protected WanderingMode wanderingMode;

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
            if (!resourceHandler.InProcessOfCollecting && 
                resourceRadar.IsResourceSourceCached && 
                resourceHandler.IsStorageEmpty &&
                resourceRadar.ResourceSource != null)
            {
                GoToResourceSource(resourceRadar.ResourceSource);
                myCollider.enabled = true;
            }
            else if (!resourceHandler.IsStorageEmpty)
            {
                GoToParentHive(parentHive);
                myCollider.enabled = false;
            }
            else if (resourceHandler.IsStorageEmpty && !resourceRadar.IsResourceSourceCached)
            {
                Wander();
                myCollider.enabled = true;
            }
            else
            {
                motor.Stop();
            }
        }

        private void GoToResourceSource(ResourceSource source)
        {
            TryMoveTo(source.transform.position);
        }
        private void GoToParentHive(Hive hive)
        {
            motor.PhysicalMoveTo(hive.Position);
        }

        private void Wander()
        {
            TryMoveTo(wanderingMode.GetNextPosition(myTransform.position));
        }

        internal void SetParentHive(Hive hive)
        {
            parentHive = hive;
        }
    }
}