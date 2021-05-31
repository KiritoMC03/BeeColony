using BeeColony.Core.Resources;
using UnityEngine;
using Utils;

namespace BeeColony.Core
{
    public abstract class ResourceSource : MonoBehaviourBase
    {
        [SerializeField] protected Resource _resource;
        
        public Resource GetResource()
        {
            var resource = Instantiate(_resource);
            //resource.gameObject.SetActive(false);
            return resource;
        }
    }
}