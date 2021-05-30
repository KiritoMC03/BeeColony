using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class SeenFlowerCache : MonoBehaviourBase
    {
        public UnityEvent OnSeen;
        public Flower _flower;

        private void Update()
        {
            //Debug.Log($"_flower not Cached: {_flower == null}");
        }

        public void Add(Flower flower)
        {
            if(_flower != null) return;
            _flower = flower;
            Debug.Log("flower add!!!");
            OnSeen?.Invoke();
        }
        
        public Flower Extract()
        {
            var flower = _flower;
            _flower = null;
            Debug.Log("flower extract!!!");
            return flower;
        }

        public Flower GetLink()
        {
            return _flower;
        }
    }
}