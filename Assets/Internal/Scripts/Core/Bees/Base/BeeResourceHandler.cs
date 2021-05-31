using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceHandler : MonoBehaviourBase
    {
        public bool IsStorageEmpty => storage.IsEmpty;
        public bool InProcessOfCollecting => collector.InProcessOfCollecting;
        
        [SerializeField] private ResourceCollector collector;
        [SerializeField] private ResourceExtractor extractor;
        [SerializeField] private BeeStorage storage;
    }
}