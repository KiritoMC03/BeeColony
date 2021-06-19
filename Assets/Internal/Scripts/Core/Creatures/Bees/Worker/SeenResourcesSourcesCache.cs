using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColonyCore.Bees
{
    public class SeenResourcesSourcesCache : MonoBehaviourBase
    {
        public UnityEvent OnClear;
        
        public bool IsSeeing => _targetResourceSource != null;

        public List<ResourceSource> _resourceSources;
        public ResourceSource _targetResourceSource;

        private void Awake()
        {
            _resourceSources = new List<ResourceSource>();
        }

        /// <returns>Was it possible to add.</returns>
        public bool Add(ResourceSource source)
        {
            if (_resourceSources.Contains(source)) return false;
            _resourceSources.Add(source);
            GetTargetResourceSource();
            return true;
        }
        
        public void Remove(ResourceSource resourceSource)
        {
            if (_resourceSources.Contains(resourceSource))
            {
                _resourceSources.Remove(resourceSource);   
            }
        }

        public ResourceSource GetTargetResourceSource()
        {
            if (_targetResourceSource == null && _resourceSources.Count > 0)
            {
                //Debug.Log("B-1");
                ChangeTargetResourceSource();
            }
            else if (_targetResourceSource != null)
            {
                if (_targetResourceSource.IsEmaciated)
                {
                    //Debug.Log("B-2");
                    ChangeTargetResourceSource();
                }
            }

            
            return _targetResourceSource;
        }

        private void ChangeTargetResourceSource()
        {
            _targetResourceSource = FindNotEmaciatedResource();
            if (_targetResourceSource != null)
            {
                _targetResourceSource.OnEmaciated.AddListener(Reset);
            }
        }

        private ResourceSource FindNotEmaciatedResource()
        {
            //Debug.Log("A");
            int number;
            for (int i = 0; i < _resourceSources.Count * 3; i++)
            {
                number = Random.Range(0, _resourceSources.Count);
                if (!_resourceSources[number].IsEmaciated)
                {
                    return _resourceSources[number];
                }
            }
            
            return null;
        }

        private void Reset()
        {
            Remove(_targetResourceSource);
            _targetResourceSource = null;
            _targetResourceSource = FindNotEmaciatedResource();
            OnClear?.Invoke();
        }
    }
}