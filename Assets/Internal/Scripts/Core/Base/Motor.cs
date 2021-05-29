using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core
{
    public abstract class Motor : MonoBehaviourBase
    {
        public UnityEvent OnDirectionChange;
        
        /// <returns> Vector2.right or Vector2.left </returns>
        public Vector2 LastDirection { get; private set; }

        [SerializeField] protected float moveSpeed = 5f;
        protected Transform MyTransform;
        protected Rigidbody2D MyRigidbody;

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
        
        protected virtual void AwakeWork() {}

        public abstract Vector2 Move();

        /// <summary> Using in FixedUpdate. </summary>
        public virtual void MoveTo(Vector3 position)
        {
            var direction = (Vector2)(position - MyTransform.position);
            if (direction.magnitude < 0.05f)
            {
                direction = Vector2.zero;
            }
            MyRigidbody.velocity = direction * (moveSpeed * Time.deltaTime);
            ChangeMoveDirection(direction);
        }

        public virtual void Stop()
        {
            MyRigidbody.velocity = Vector3.zero;
        }
        
        protected virtual Vector2 ChangeMoveDirection(Vector2 currentDirection)
        {
            var differentDirections = !Mathf.Approximately(currentDirection.normalized.x, LastDirection.x);
            if (currentDirection.x != 0f && differentDirections)
            {
                OnDirectionChange?.Invoke();
                LastDirection = currentDirection.normalized;
            }

            return LastDirection;
        }
    }
}