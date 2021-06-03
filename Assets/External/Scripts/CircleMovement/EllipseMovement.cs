using System.Collections;
using UnityEngine;
using Utils;

namespace PlanetsColony
{
    public class EllipseMovement : MonoBehaviourBase
    {
        [SerializeField] private Transform movableObject;
        [SerializeField] internal Ellipse ellipsePath = new Ellipse(10, 10);
        [Range(0f, 1f)]
        [SerializeField] internal float progress = 0f;
        [SerializeField] internal float period = 3f;
        [SerializeField] internal bool isActive = true;

        private Transform _transform = null;
        private Vector2 _tempOrbitPosition2D;
        private Vector3 _tempOrbitPosition3D;
        private Vector3 _startPosition = Vector3.zero;

        private void Awake()
        {
            _transform = transform;
            _startPosition = _transform.position;
            if (movableObject == null)
            {
                isActive = false;
            }
        }
        
        void SetOrbitingObjectPosition()
        {
            _tempOrbitPosition2D = ellipsePath.Evaluate(progress);
            movableObject.localPosition = _tempOrbitPosition2D + (Vector2)_startPosition;
        }

        IEnumerator AnimateOrbitRoutine()
        {
            if (period < 0.1f)
            {
                period = 0.1f;
            }

            float orbitSpeed = 1f / period;

            while (isActive)
            {
                progress += Time.deltaTime * orbitSpeed;
                progress %= 1f;
                SetOrbitingObjectPosition();

                yield return null;
            }
        }

        private void OnEnable()
        {
            if (isActive)
            {
                SetOrbitingObjectPosition();
            }
            
            StartCoroutine(AnimateOrbitRoutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}