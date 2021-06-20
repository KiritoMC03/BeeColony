using System;
using System.Collections;
using BeeColonyCore.Resources;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColonyCore
{
    public abstract class ResourceSource : MonoBehaviourBase
    {
        public UnityEvent OnEmaciated;
        
        public bool IsEmaciated = false;

        [SerializeField] protected float timeToGenerate = 3f;
        private int count = 3;

        public Resource GetResource()
        {
            var resource = new Pollen(Pollen.AvailableType.Flower, Random.Range(1, 5));
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