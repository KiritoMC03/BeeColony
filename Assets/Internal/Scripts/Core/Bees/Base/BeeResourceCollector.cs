using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceCollector : MonoBehaviourBase
    {
        public UnityEvent OnResourceCollected;
        
        [SerializeField] private SeenFlowerCache seenFlowerCache;
        
        private bool _resourceNoticed = false;
        public bool InProcessOfCollecting { get; private set; } = false;
        public bool IsItCollected { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var resource = other.GetComponent<Resource>();
            if (resource == seenFlowerCache.GetLink())
            {
                InProcessOfCollecting = true;
                StartCoroutine(CollectRoutine(resource, 8));
            }
        }

        private IEnumerator CollectRoutine(Resource resource, float collectSpeed)
        {
            yield return new WaitForSeconds(10 / collectSpeed);
            var f = seenFlowerCache.ExtractFlower();
            Destroy(resource.gameObject);
            
            InProcessOfCollecting = false;
            IsItCollected = true;
            OnResourceCollected?.Invoke();
        }
    }
}