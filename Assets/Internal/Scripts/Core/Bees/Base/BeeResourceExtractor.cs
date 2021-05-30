using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceExtractor : MonoBehaviourBase
    {
        public UnityEvent OnExtracted;
        
        [SerializeField] private SeenFlowerCache seenFlowerCache;
        [SerializeField] private BeeResourceStorage resourceStorage;
        [SerializeField] private BeeBase _bee;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var hive = other.GetComponent<Hive>();
            Debug.Log($"hive is null: {hive == null}");
            Debug.Log($"storage is empty: {resourceStorage.IsEmpty}");
            if (hive != null && !resourceStorage.IsEmpty /* && hive == _bee.ParentHive*/)
            {
                Debug.Log("Extract!");
                resourceStorage.Extract();
                OnExtracted?.Invoke();
            }
        }
    }
}