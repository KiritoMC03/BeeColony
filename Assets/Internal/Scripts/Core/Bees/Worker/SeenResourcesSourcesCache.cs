using System;
using System.Collections.Generic;
using UnityEngine.Events;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColony.Core.Bees.Worker
{
    public class SeenResourcesSourcesCache : MonoBehaviourBase
    {
        public UnityEvent OnClear;
        
        public bool IsSeeing => _resourceSources != null && _resourceSources.Count > 0;

        private List<ResourceSource> _resourceSources;
        private ResourceSource _targetResourceSource;

        private void Awake()
        {
            _resourceSources = new List<ResourceSource>();
        }

        /// <returns>Was it possible to add.</returns>
        public bool Add(ResourceSource source)
        {
            _resourceSources.Add(source);
            return true;
            
            /*
            if (!IsSeeing)
            {
                if (_resourceSources != null)
                {
                    _resourceSources.OnEmaciated.RemoveAllListeners();
                }

                _resourceSources = source;
                source.OnEmaciated.AddListener(Clear);
                return true;
            }
            */

        }

        /*
        public void AddOrReplace(ResourceSource source)
        {
            _resourceSources = source;
        }
        */
        
        public void Clear(ResourceSource resourceSource)
        {
            _resourceSources.Remove(resourceSource);
            OnClear?.Invoke();
        }

        public ResourceSource GetTargetResourceSource()
        {
            if (_targetResourceSource == null && _resourceSources.Count > 0)
            {
                _targetResourceSource = _resourceSources[Random.Range(0, _resourceSources.Count - 1)];
            }
            return _targetResourceSource;
        }
    }
}