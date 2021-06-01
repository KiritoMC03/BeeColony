using System;
using System.Collections;
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

        private void OnEnable()
        {
            StartCoroutine(PeriodicInspection());
        }

        public void EnableRadar()
        {
            Debug.Log("Enable");
            _collider.enabled = true;
        }
        
        public void DisableRadar()
        {
            Debug.Log("Disable");
            _collider.enabled = false;
        }

        public void ReloadRadar()
        {
            DisableRadar();
            EnableRadar();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"A");
            var resourceSource = other.GetComponent<ResourceSource>();
            if (resourceSource != null && !resourceSource.IsEmaciated)
            {
                var sendResult = SendResourceSourceToCache(resourceSource);
                if (sendResult)
                {
                    OnResourceSourceCached?.Invoke();
                }
            }
            else
            {
                seenResourcesSourcesCache.Clear();
            }
        }

        /// <returns>Was it possible to add.</returns>
        private bool SendResourceSourceToCache(ResourceSource source)
        {
            return seenResourcesSourcesCache.Add(source);
        }

        private IEnumerator PeriodicInspection()
        {
            while (true)
            {
                if (!IsResourceSourceCached && _collider.enabled)
                {
                    ReloadRadar();
                }
                yield return new WaitForSeconds(4f);
            }
        }
    }
}