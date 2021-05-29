using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core
{
    public abstract class Motor : MonoBehaviourBase
    {
        public UnityEvent onDirectionChange;

        [SerializeField] protected float moveSpeed = 5f;
        protected Transform MyTransform;
        protected Rigidbody2D MyRigidbody;

        private Vector2 _tempDirection = new Vector2();

        private void Awake()
        {
            InitFields();
            AwakeWork();
        }

        private void InitFields()
        {
            MyTransform = transform;
            MyRigidbody = GetSafeComponent<Rigidbody2D>();
        }

        public abstract Vector2 Move();

        /// <summary> Using in FixedUpdate. </summary>
        public virtual void MoveTo(Vector3 position)
        {
            MyRigidbody.velocity = Vector3.zero;
            MyRigidbody.velocity = (position - MyTransform.position) * (moveSpeed * Time.deltaTime);
        }

        public virtual void Stop()
        {
            MyRigidbody.velocity = Vector3.zero;
        }
        
        protected virtual void AwakeWork()
        {
        }
    }
}