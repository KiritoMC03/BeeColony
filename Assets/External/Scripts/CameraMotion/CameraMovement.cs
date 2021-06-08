using System;
using UnityEngine;

namespace CameraMotion
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float speed = 1f;
        [SerializeField] private bool ignoreZoom;
        [SerializeField] private CameraZoom zoom;

        private Transform _cameraTransform;
        private Vector3 _touсh;
        private Vector2 _currentPosition;

        private void Awake()
        {
            _cameraTransform = camera.transform;
        }
        
        private void Update()
        {
            if(zoom.IsZooming) return;
            if (Input.GetMouseButtonDown(0))
            {
                _touсh = camera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                var direction = _touсh - camera.ScreenToWorldPoint(Input.mousePosition);
                _cameraTransform.position += direction;
            }
        }
    }
}