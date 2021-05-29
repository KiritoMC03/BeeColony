using System;
using System.Collections.Generic;
using Utils;

namespace BeeColony.Core.Bees
{
    public class SeenFlowersCache : MonoBehaviourBase
    {
        private Queue<Flower> _flowers;

        private void Awake()
        {
            _flowers = new Queue<Flower>();
        }

        public void AddFlower(Flower flower)
        {
            _flowers.Enqueue(flower);
        }
        
        public Flower ExtractFlower()
        {
            return _flowers.Dequeue();
        }
    }
}