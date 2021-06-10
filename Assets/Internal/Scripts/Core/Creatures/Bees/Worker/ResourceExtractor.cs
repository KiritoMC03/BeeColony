using BeeColony.Core.Bees;
using BeeColony.Core.Buildings;
using UnityEngine;
using UnityEngine.Events;

namespace BeeColony.Core.Bees
{
    public class ResourceExtractor : ResourceTransfer
    {
        public UnityEvent OnExtracted;
        
        protected override void OnTriggerEnter2D_Work(Collider2D other)
        {
            var hive = other.GetComponent<Hive>();

            if (hive != null && !storage.IsEmpty)
            {
                hive.AcceptResource(storage.Extract());
                OnExtracted?.Invoke();
            }
        }
    }
}