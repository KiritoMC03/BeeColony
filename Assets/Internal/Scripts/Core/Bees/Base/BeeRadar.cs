using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeRadar : MonoBehaviourBase
    {
        public UnityEvent OnResourceSourceCached;
        public bool IsResourceSourceCached => seenResourcesSourcesCache.IsSeeing;
        public ResourceSource ResourceSource => seenResourcesSourcesCache.GetLink();
        
        [SerializeField] private SeenResourcesSourcesCache seenResourcesSourcesCache;
        
        [Header("Recommend True")]
        [SerializeField] private bool isTrigger = true;
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetSafeComponent<Collider2D>();
            _collider.isTrigger = isTrigger;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var resourceSource = other.GetComponent<ResourceSource>();

            if (resourceSource != null)
            {
                var sendResult = SendResourceSourceToCache(resourceSource);
                if (sendResult)
                {
                    OnResourceSourceCached?.Invoke();
                }
            }
        }

        /// <returns>Was it possible to add.</returns>
        private bool SendResourceSourceToCache(ResourceSource source)
        {
            return seenResourcesSourcesCache.Add(source);
        }
    }
}