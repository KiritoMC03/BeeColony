using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColonyCore
{
    public abstract class Motor : MonoBehaviourBase
    {
        public UnityEvent OnDirectionChange;
        
        /// <returns> Vector2.right or Vector2.left </returns>
        public Vector2 LastDirection { get; private set; }

        [SerializeField] protected float moveSpeed = 5f;
        protected Transform MyTransform;
        protected Rigidbody2D MyRigidbody;  
        
        private Vector2 _input;

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
        
        
        /// <summary> Using in FixedUpdate. </summary>
        public virtual Vector2 PhysicalMove()
        {
            var movement = GetInput() * (Time.deltaTime * moveSpeed);
            MyRigidbody.velocity = movement;
            return movement;
        }

        /// <summary> Using in FixedUpdate. </summary>
        public virtual void PhysicalMoveTo(Vector3 position)
        {
            var direction = (Vector2)(position - MyTransform.position);
            if (direction.magnitude < 0.05f)
            {
                direction = Vector2.zero;
            }
            MyRigidbody.velocity = direction.normalized * (moveSpeed * Time.deltaTime);
            ChangeMoveDirection(direction);
        }

        public virtual void Stop()
        {
            MyRigidbody.velocity = Vector3.zero;
        }
        
        protected virtual Vector2 ChangeMoveDirection(Vector2 currentDirection)
        {
            var different = currentDirection.normalized.x - LastDirection.x;
            if (currentDirection.x != 0f && (different > 0.1f) || different < -0.1f)
            {
                LastDirection = currentDirection.normalized;
                OnDirectionChange?.Invoke();
            }

            return LastDirection;
        }
        
        
        

        
        
        private static Vector2 GetInput()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            return new Vector2(x, y);
        }
    }
}