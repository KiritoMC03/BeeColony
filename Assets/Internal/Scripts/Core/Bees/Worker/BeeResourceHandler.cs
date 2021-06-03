using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Worker
{
    public class BeeResourceHandler : MonoBehaviourBase
    {
        public UnityEvent OnReplenished;
        public UnityEvent OnDevastated;
        public UnityEvent OnStorageChange;
        
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

        private void OnEnable()
        {
            collector.OnCollected.AddListener(() => OnReplenished?.Invoke());
            extractor.OnExtracted.AddListener(() => OnDevastated?.Invoke());
        }

        private void OnDisable()
        {
            collector.OnCollected.RemoveAllListeners();
            extractor.OnExtracted.RemoveAllListeners();
        }
    }
}