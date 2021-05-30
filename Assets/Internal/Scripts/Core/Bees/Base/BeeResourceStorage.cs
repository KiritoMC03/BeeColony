using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeResourceStorage : MonoBehaviourBase
    {
        public bool IsEmpty => (_resource == null);
        public Resource _resource;

        public void Add(Resource resource)
        {
            Debug.Log("add!!!!!!!!!!!!!!!!!!!!!!");
            _resource = resource;
        }

        public Resource Extract()
        {
            Debug.Log("Extract!!!!!!!!!!!!!!!!!!!!!!");
            var temp = _resource;
            _resource = null;
            return temp;
        }
    }
}