using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceCollector : MonoBehaviourBase
    {
        public UnityEvent OnCollected;
        
        public bool InProcessOfCollecting { get; private set; } = false;
        public bool IsItCollected { get; private set; } = false;
        
        [SerializeField] private SeenFlowerCache seenFlowerCache;
        [SerializeField] private BeeResourceStorage resourceStorage;
        
        private bool _resourceNoticed = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var resource = other.GetComponent<Resource>();
            Debug.Log($"res is null: {resource == null}");
            if (resource != null && resource == seenFlowerCache.GetLink())
            {
                Debug.Log("resource triggered", resource.gameObject);
                InProcessOfCollecting = true;
                StartCoroutine(CollectRoutine(resource, 8));
            }
        }

        private IEnumerator CollectRoutine(Resource resource, float collectSpeed)
        {
            yield return new WaitForSeconds(10 / collectSpeed);
            resourceStorage.Add(seenFlowerCache.Extract());
            //Destroy(resource.gameObject);
            //Destroy(f.);
            
            InProcessOfCollecting = false;
            IsItCollected = true;
            OnCollected?.Invoke();
        }
    }
}