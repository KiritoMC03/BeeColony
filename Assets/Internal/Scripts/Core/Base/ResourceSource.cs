using System;
using System.Collections;
using BeeColony.Core.Resources;
using UnityEngine;
using Utils;

namespace BeeColony.Core
{
    public abstract class ResourceSource : MonoBehaviourBase
    {
        public bool IsEmaciated = false;
        private event Action OnEmaciated;
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

        public void StartListenForEmaciated(Action action)
        {
            Debug.Log("StatListen");
            OnEmaciated += action;
        }
        
        public void EndListenForEmaciated(Action action)
        {
            OnEmaciated -= action;
        }

        private IEnumerator Generate()
        {
            yield return new WaitForSeconds(timeToGenerate);
            IsEmaciated = false;
        }
    }
}