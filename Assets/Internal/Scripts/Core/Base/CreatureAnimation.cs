using BeeColonyCore.Bees;
using UnityEngine;
using Utils;

namespace BeeColonyCore
{
    [RequireComponent(typeof(Animator))]
    public class CreatureAnimation : MonoBehaviourBase
    {
        [SerializeField] private AnimationClip startingAnimation;
        [SerializeField] private Motor motor;
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
            motor.OnDirectionChange.AddListener(InvertDirection);
            Play(startingAnimation.name);
        }

        private void Play(string animationName)
        {
            _animator.Play(animationName);
        }

        private void InvertDirection()
        {
            if ((motor.LastDirection.x < 0f && IsSeeRight) || (motor.LastDirection.x > 0f && !IsSeeRight))
            {
                _direction = new Vector3(-_direction.x, _direction.y, _direction.z);
                _transform.localScale = _direction;
                IsSeeRight.Invert();
            }
        }

        private void OnDisable()
        {
            motor.OnDirectionChange.RemoveAllListeners();
        }
    }
}