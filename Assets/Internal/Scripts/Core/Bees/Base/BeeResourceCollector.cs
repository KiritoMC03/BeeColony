using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceCollector : MonoBehaviourBase
    {
        public UnityEvent OnResourceNoticed;
        private bool _resourceNoticed = false;
        public bool IsCollected { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var resource = other.GetComponent<Resource>();
            if (resource != null)
            {
                IsCollected = true;
                OnResourceNoticed?.Invoke();
            }
        }
    }
}