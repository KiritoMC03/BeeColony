using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees
{
    public class ColliderController : MonoBehaviourBase
    {
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetSafeComponent<Collider2D>();
        }

        public void Enable()
        {
            _collider.enabled = true;
        }

        public void Disable()
        {
            _collider.enabled = false;
        }
    }
}