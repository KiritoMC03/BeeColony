using System.Collections.Generic;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class SeenFlowerCache : MonoBehaviourBase
    {
        public UnityEvent OnSeen;
        private Flower _flower;

        public void AddFlower(Flower flower)
        {
            if(_flower != null) return;
            _flower = flower;
            OnSeen?.Invoke();
        }
        
        public Flower ExtractFlower()
        {
            var flower = _flower;
            _flower = null;
            return flower;
        }
    }
}