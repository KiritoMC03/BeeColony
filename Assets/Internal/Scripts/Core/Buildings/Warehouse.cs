using System;
using System.Collections.Generic;
using Utils;

namespace BeeColony.Core.Buildings
{
    public class Warehouse : MonoBehaviourBase
    {
        public int count;
        private List<Resource> _resources;

        private void Awake()
        {
            _resources = new List<Resource>();
        }

        public void Add(Resource resource)
        {
            _resources.Add(resource);
            count = _resources.Count;
        }
    }
}