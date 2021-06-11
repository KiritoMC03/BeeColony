using System;
using System.Collections.Generic;
using BeeColony.Core.Resources;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Buildings
{
    public class Warehouse : MonoBehaviourBase
    {
        public UnityEvent OnHoneycombsCountChange;
        
        private List<Honeycomb> _honeycombs = new List<Honeycomb>();

        public void Add(Resource resource)
        {
            if (resource is Honeycomb honeycomb)
            {
                AddHoneycomb(honeycomb);
            }
        }

        public int GetHoneycombsCount()
        {
            return _honeycombs.Count;
        }

        private void AddHoneycomb(Honeycomb honeycomb)
        {
            _honeycombs.Add(honeycomb);
            OnHoneycombsCountChange?.Invoke();
        }
    }
}