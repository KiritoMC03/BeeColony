using System;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class SeenResourcesSourcesCache : MonoBehaviourBase
    {
        public bool IsSeeing => _resourceSource != null;
        public ResourceSource _resourceSource;

        /// <returns>Was it possible to add.</returns>
        public bool Add(ResourceSource source)
        {
            if (!IsSeeing)
            {
                _resourceSource = source;
                return true;
            }

            return false;
        }

        public void AddOrReplace(ResourceSource source)
        {
            _resourceSource = source;
        }

        public void Clear()
        {
            _resourceSource = null;
        }

        public ResourceSource GetLink()
        {
            return _resourceSource;
        }
    }
}