using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceHandler : MonoBehaviourBase
    {
        private UnityEvent OnStorageChange;
        
        public bool IsStorageEmpty => storage.IsEmpty;
        public bool InProcessOfCollecting => collector.InProcessOfCollecting;
        
        [SerializeField] private ResourceCollector collector;
        [SerializeField] private ResourceExtractor extractor;
        [SerializeField] private BeeStorage storage;

        private void Awake()
        {
            OnStorageChange ??= new UnityEvent();
            storage.OnStorageChange += () => OnStorageChange?.Invoke();
        }

        public void StartListenStorageChange(UnityAction call)
        {
            Debug.Log($"B. IsNull: {OnStorageChange == null} ");
            OnStorageChange.AddListener(call);
        }
        
        public void EndListenStorageChange(UnityAction call)
        {
            OnStorageChange.RemoveListener(call);
        }
    }
}