using System;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Worker
{
    public class BeeStorage : MonoBehaviourBase
    {
        public event Action OnStorageChange;
        
        public bool IsEmpty => _resource == null;
        public Resource _resource;

        public void Add(Resource resource)
        {
            if (_resource == null)
            {
                _resource = resource;
                
                Debug.Log($"ADD End: {_resource != null}");
                OnStorageChange?.Invoke();
            }
        }

        public Resource Extract()
        {
            var temp = _resource;
            _resource = null;
            OnStorageChange?.Invoke();

            return temp;
        }
    }
}