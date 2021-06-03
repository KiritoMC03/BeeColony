using BeeColony.Core.Bees.Base;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Worker
{
    public class ResourceExtractor : ResourceTransfer
    {
        public UnityEvent OnExtracted;
        
        protected override void OnTriggerEnter2D_Work(Collider2D other)
        {
            var hive = other.GetComponent<Hive>();

            if (hive != null)
            {
                if (!storage.IsEmpty)
                {
                    storage.Extract();
                    Debug.Log($"Extract");
                    OnExtracted?.Invoke();
                }
            }
        }
    }
}