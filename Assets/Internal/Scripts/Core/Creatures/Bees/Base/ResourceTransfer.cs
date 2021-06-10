using BeeColony.Core.Bees;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees
{
    public class ResourceTransfer : MonoBehaviourBase
    {
        [SerializeField] protected BeeStorage storage;
        [Header("Recommend False")]
        [SerializeField] protected bool isTrigger = false;
        protected Collider2D _collider;

        private void Awake()
        {
            _collider = GetSafeComponent<Collider2D>();
            _collider.isTrigger = isTrigger;
            Awake_Work();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter2D_Work(other);
        }

        protected virtual void Awake_Work() {}
        protected virtual void OnTriggerEnter2D_Work(Collider2D other) {}
    }
}