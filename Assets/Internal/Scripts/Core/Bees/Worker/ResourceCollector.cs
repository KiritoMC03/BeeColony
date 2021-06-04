using System.Collections;
using BeeColony.Core.Bees.Base;
using UnityEngine;
using Utils;
using UnityEngine.Events;

namespace BeeColony.Core.Bees.Worker
{
    public class ResourceCollector : ResourceTransfer
    {
        public UnityEvent OnCollected;
        
        public bool InProcessOfCollecting = false;
        
        [SerializeField] private float collectSpeed = 1f;
        private Coroutine _collectingRoutine;
        
        protected override void OnTriggerEnter2D_Work(Collider2D other)
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