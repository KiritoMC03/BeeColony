using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Worker
{
    public class SeenResourcesSourcesCache : MonoBehaviourBase
    {
        public UnityEvent OnClear;
        
        public bool IsSeeing => _resourceSource != null;
        public ResourceSource _resourceSource;
        
        /// <returns>Was it possible to add.</returns>
        public bool Add(ResourceSource source)
        {
            if (!IsSeeing)
            {
                if (_resourceSource != null)
                {
                    _resourceSource.OnEmaciated.RemoveAllListeners();
                }

                _resourceSource = source;
                source.OnEmaciated.AddListener(Clear);
                return true;
            }

            return false;
        }

        public void AddOrReplace(ResourceSource source)
        {
            _resourceSource = source;
        }

        public void Clear()
        {
            _resourceSource = null;
            OnClear?.Invoke();
        }

        public ResourceSource GetLink()
        {
            return _resourceSource;
        }
    }
}