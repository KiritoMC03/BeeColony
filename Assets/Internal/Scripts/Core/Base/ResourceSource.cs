using System;
using System.Collections;
using BeeColony.Core.Resources;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core
{
    public abstract class ResourceSource : MonoBehaviourBase
    {
        public bool IsEmaciated = false;
        public UnityEvent OnEmaciated;
        [SerializeField] protected Resource _resource;
        [SerializeField] protected float timeToGenerate = 3f;

        public Resource GetResource()
        {
            var resource = Instantiate(_resource);
            IsEmaciated = true;
            OnEmaciated?.Invoke();
            StartCoroutine(Generate());
            return resource;
        }

        private IEnumerator Generate()
        {
            yield return new WaitForSeconds(timeToGenerate);
            IsEmaciated = false;
        }
    }
}