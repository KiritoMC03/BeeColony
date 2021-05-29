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
        private bool _resourceNoticed = false;
        public bool IsCollected { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var resource = other.GetComponent<Resource>();
            if (resource != null)
            {
                IsCollected = true;
                StartCoroutine(CollectRoutine(resource, 8));
            }
        }

        private IEnumerator CollectRoutine(Resource resource, float collectSpeed)
        {
            yield return new WaitForSeconds(10 / collectSpeed);
            Destroy(resource.gameObject);
            OnResourceCollected?.Invoke();
            IsCollected = false;
        }
    }
}