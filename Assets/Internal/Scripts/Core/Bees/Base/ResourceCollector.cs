using System;
using System.Collections;
using UnityEngine;
using Utils;
using BeeColony.Core.Resources;
using UnityEngine.Events;

namespace BeeColony.Core.Bees.Base
{
    public class ResourceCollector : MonoBehaviourBase
    {
        public UnityEvent OnCollected;
        
        public bool InProcessOfCollecting = false;
        
        [SerializeField] private BeeStorage storage;
        [SerializeField] private float collectSpeed = 1f;
        [Header("Recommend False")]
        [SerializeField] private bool isTrigger = false;
        private Collider2D _collider;
        private Coroutine _collectingRoutine;
        

        private void Awake()
        {
            _collider = GetSafeComponent<Collider2D>();
            _collider.isTrigger = isTrigger;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var resourceSource = other.GetComponent<ResourceSource>();

            if (resourceSource != null)
            {
                if (storage.IsEmpty)
                {
                    resourceSource.OnEmaciated.AddListener(StopCollecting);
                    _collectingRoutine = StartCoroutine(CollectingRoutine(resourceSource, collectSpeed));
                }
            }
        }
        
        private IEnumerator CollectingRoutine(ResourceSource resourceSource, float speed)
        {
            InProcessOfCollecting = true;
            yield return new WaitForSeconds(5f / speed);
                
            var resource = resourceSource.GetResource();
            if (resource != null)
            {
                storage.Add(resource);
                OnCollected?.Invoke();
            }
            InProcessOfCollecting = false;
        }

        private void StopCollecting()
        {
            if (_collectingRoutine != null)
            {
                StopCoroutine(_collectingRoutine);
                InProcessOfCollecting = false;
            }
        }
    }
}