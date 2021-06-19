using System;
using System.Collections;
using BeeColonyCore.Bees;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColonyCore.Bees
{
    public class BeeResourceRadar : MonoBehaviourBase
    {
        public UnityEvent OnResourceSourceCached;
        public bool IsResourceSourceCached => seenResourcesSourcesCache.IsSeeing;
        public ResourceSource ResourceSource => seenResourcesSourcesCache.GetTargetResourceSource();
        
        [SerializeField] private SeenResourcesSourcesCache seenResourcesSourcesCache;
        [SerializeField] private float radius = 10f;
        [SerializeField] private float scanPeriod = 4f;
        
        [Header("Recommend True")]
        [SerializeField] private bool isTrigger = true;
        private CircleCollider2D _collider;

        private void Awake()
        {
            _collider = GetSafeComponent<CircleCollider2D>();
            _collider.isTrigger = isTrigger;
            _collider.radius = radius;
        }

        private void OnEnable()
        {
            StartCoroutine(PeriodicScanning());
            seenResourcesSourcesCache.OnClear.AddListener(ReloadRadar);
        }

        private void OnDisable()
        {
            seenResourcesSourcesCache.OnClear.RemoveAllListeners();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log($"Trigger: {other.gameObject}");
            var resourceSource = other.GetComponent<ResourceSource>();
            if (resourceSource != null && !resourceSource.IsEmaciated)
            {
                var sendResult = SendResourceSourceToCache(resourceSource);
                if (sendResult)
                {
                    OnResourceSourceCached?.Invoke();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var resourceSource = other.GetComponent<ResourceSource>();
            seenResourcesSourcesCache.Remove(resourceSource);
        }

        /// <returns>Was it possible to add.</returns>
        private bool SendResourceSourceToCache(ResourceSource source)
        {
            return seenResourcesSourcesCache.Add(source);
        }

        private IEnumerator PeriodicScanning()
        {
            while (true)
            {
                if (!IsResourceSourceCached && _collider.enabled)
                {
                    ReloadRadar();
                }
                yield return new WaitForSeconds(scanPeriod);
            }
        }

        public void ReloadRadar()
        {
            DisableRadar();
            EnableRadar();
        }

        public void EnableRadar()
        {
            _collider.enabled = true;
        }
        
        public void DisableRadar()
        {
            _collider.enabled = false;
        }
    }
}