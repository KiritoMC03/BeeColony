using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    [RequireComponent(typeof(Animator))]
    public class BeeAnimation : MonoBehaviourBase
    {
        [SerializeField] private AnimationClip startingAnimation;
        [SerializeField] private BeeMotor beeMotor;
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
            beeMotor.onDirectionChange.AddListener(InvertDirection);
            Play(startingAnimation.name);
        }

        private void Play(string animationName)
        {
            _animator.Play(animationName);
        }

        private void InvertDirection()
        {
            _direction = new Vector3(-_direction.x, _direction.y, _direction.z);
            _transform.localScale = _direction;
        }

        private void OnDisable()
        {
            beeMotor.onDirectionChange.RemoveAllListeners();
        }
    }
}