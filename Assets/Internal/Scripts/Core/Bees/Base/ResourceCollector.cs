using UnityEngine;
using Utils;
using BeeColony.Core.Resources;

namespace BeeColony.Core.Bees.Base
{
    public class ResourceCollector : MonoBehaviourBase
    {
        [SerializeField] private BeeStorage storage;
        [Header("Recommend False")]
        [SerializeField] private bool isTrigger = false;
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetSafeComponent<Collider2D>();
            _collider.isTrigger = isTrigger;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var resourceSource = other.GetComponent<ResourceSource>();

            if (resourceSource != null)
            {
                if (storage.IsEmpty)
                {
                    var resource = resourceSource.GetResource();
                    if (resource != null)
                    {
                        storage.Add(resource);
                    }
                }
            }
        }
    }
}