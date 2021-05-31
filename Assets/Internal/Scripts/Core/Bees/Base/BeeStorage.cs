using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeStorage : MonoBehaviourBase
    {
        public bool IsEmpty => _resource == null;
        public Resource _resource;

        public void Add(Resource resource)
        {
            if (_resource == null)
            {
                _resource = resource;
            }
        }

        public Resource Extract()
        {
            var temp = _resource;
            _resource = null;

            return temp;
        }
    }
}