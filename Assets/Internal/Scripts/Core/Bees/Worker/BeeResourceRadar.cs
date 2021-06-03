using System;
using System.Collections;
using BeeColony.Core.Bees.Base;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Worker
{
    public class BeeResourceRadar : MonoBehaviourBase
    {
        public UnityEvent OnResourceSourceCached;
        public bool IsResourceSourceCached => seenResourcesSourcesCache.IsSeeing;
        public ResourceSource ResourceSource => seenResourcesSourcesCache.GetLink();
        
        [SerializeField] private SeenResourcesSourcesCache seenResourcesSourcesCache;
        
        [Header("Recommend True")]
        [SerializeField] private bool isTrigger = true;
        private Collider2D _collider;
        private Coroutine _periodicInspectionRoutine;

        private void Awake()
        {
            _collider = GetSafeComponent<Collider2D>();
            _collider.isTrigger = isTrigger;
        }

        private void OnEnable()
        {
            StartCoroutine(PeriodicInspection());
            seenResourcesSourcesCache.OnClear.AddListener(ReloadRadar);
        }

        private void OnDisable()
        {
            if (_periodicInspectionRoutine != null)
            {
                StopCoroutine(_periodicInspectionRoutine);
            }
            seenResourcesSourcesCache.OnClear.RemoveAllListeners();
        }

        public void EnableRadar()
        {
            _collider.enabled = true;
        }
        
        public void DisableRadar()
        {
            _collider.enabled = false;
        }

        public void ReloadRadar()
        {
            DisableRadar();
            EnableRadar();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
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