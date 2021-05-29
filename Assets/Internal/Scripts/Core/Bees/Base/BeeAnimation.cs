using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    [RequireComponent(typeof(Animator))]
    public class BeeAnimation : MonoBehaviourBase
    {
        [SerializeField] private AnimationClip startingAnimation;
        [SerializeField] private BeeMotor beeMotor;
        [SerializeField] protected bool IsSeeRight = true;
        private Animator _animator;
        private Transform _transform;
        private Vector3 _direction;

        private void Awake()
        {
            InitFields();
            _direction = _transform.localScale;
        }

        private void InitFields()
        {
            _transform = transform;
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            beeMotor.OnDirectionChange.AddListener(InvertDirection);
            Play(startingAnimation.name);
        }

        private void Play(string animationName)
        {
            _animator.Play(animationName);
        }

        private void InvertDirection()
        {
            Debug.Log("x: " + beeMotor.LastDirection.x);
            if ((beeMotor.LastDirection.x < 0f && IsSeeRight) || (beeMotor.LastDirection.x > 0f && !IsSeeRight))
            {
                _direction = new Vector3(-_direction.x, _direction.y, _direction.z);
                _transform.localScale = _direction;
                IsSeeRight.Invert();
            }
        }

        private void OnDisable()
        {
            beeMotor.OnDirectionChange.RemoveAllListeners();
        }
    }
}