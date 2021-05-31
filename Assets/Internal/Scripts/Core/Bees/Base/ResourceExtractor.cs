using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class ResourceExtractor : MonoBehaviourBase
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
            var hive = other.GetComponent<Hive>();

            if (hive != null)
            {
                if (!storage.IsEmpty)
                {
                    storage.Extract();
                }
            }
        }
    }
}