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
        public UnityEvent OnEmaciated;
        
        public bool IsEmaciated = false;

        [SerializeField] protected float timeToGenerate = 3f;
        private int count = 3;

        public Resource GetResource()
        {
            var resource = new Honeycomb();
            IsEmaciated = true;
            OnEmaciated?.Invoke();
            StartCoroutine(Generate());
            count--;
            if(count <= 0) Delete();
            return resource;
        }

        private void Delete()
        {
            Destroy(gameObject);
        }

        private IEnumerator Generate()
        {
            yield return new WaitForSeconds(timeToGenerate);
            IsEmaciated = false;
        }
    }
}