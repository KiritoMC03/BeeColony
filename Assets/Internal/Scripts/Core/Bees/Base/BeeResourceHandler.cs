using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceHandler : MonoBehaviourBase
    {
        public bool IsStorageEmpty => storage.IsEmpty;
        
        [SerializeField] private ResourceCollector collector;
        [SerializeField] private ResourceExtractor extractor;
        [SerializeField] private BeeStorage storage;
    }
}