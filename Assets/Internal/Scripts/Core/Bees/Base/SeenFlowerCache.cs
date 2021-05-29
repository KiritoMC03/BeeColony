using System.Collections.Generic;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class SeenFlowersCache : MonoBehaviourBase
    {
        public UnityEvent OnSeen;
        private Queue<Flower> _flowers;

        private void Awake()
        {
            _flowers = new Queue<Flower>();
        }

        public void AddFlower(Flower flower)
        {
            _flowers.Enqueue(flower);
            if (_flowers.Count == 1)
            {
                OnSeen?.Invoke();
            }
        }
        
        public Flower ExtractFlower()
        {
            if (_flowers.Count == 0)
            {
                return null;
            }
            var flower = _flowers.Dequeue();
            return flower;
        }
    }
}