using UnityEngine;
using Utils;

namespace CameraMotion
{
    public class CameraZoom : MonoBehaviourBase
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float min = 1f;
        [SerializeField] private float max = 10f;
        [SerializeField] private float _sensitivity = 1f;

        private Transform _cameraTransform;
        private Vector3 _touсh;
        private Vector2 _currentPosition;

        private Touch _touchZero;
        private Touch _touchFirst;
        private Vector2 _lastTouchZero;
        private Vector2 _lastTouchFirst;
        private float _lastDistance;
        private float _currentDistance;

        private void Awake()
        {
            _cameraTransform = camera.transform;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touсh = camera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.touchCount == 2)
            {
                Zoom(ProcessTouch() * Time.deltaTime * _sensitivity);
            }
            else if (Input.GetMouseButton(0))
            {
                var direction = _touсh - camera.ScreenToWorldPoint(Input.mousePosition);
                _cameraTransform.position += direction;
            }

            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }

        private void Zoom(float increment)
        {
            camera.orthographicSize = Mathf.Clamp(
                camera.orthographicSize - increment,
                min,
                max);
        }

        private float ProcessTouch()
        {
            _touchZero = Input.GetTouch(0);
            _touchFirst = Input.GetTouch(1);

            _lastTouchZero = _touchZero.position - _touchZero.deltaPosition;
            _lastTouchFirst = _touchFirst.position - _touchFirst.deltaPosition;

            _lastDistance = (_lastTouchZero - _lastTouchFirst).magnitude;
            _currentDistance = (_touchZero.position - _touchFirst.position).magnitude;

            return _currentDistance - _lastDistance;
        }
    }
}