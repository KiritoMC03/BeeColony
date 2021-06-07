using UnityEngine;

namespace CameraMotion
{
    public class MovementRestriction : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Vector2 positiveLimit = new Vector2(10f, 10f);
        [SerializeField] private Vector2 negativeLimit = new Vector2(-10f, -10f);

        private Transform _cameraTransform;

        private void Awake()
        {
            _cameraTransform = camera.transform;
        }

        private void LateUpdate()
        {
            _cameraTransform.position = new Vector3(
                Mathf.Clamp(_cameraTransform.position.x, negativeLimit.x, positiveLimit.x),
                Mathf.Clamp(_cameraTransform.position.y, negativeLimit.y, positiveLimit.y),
                _cameraTransform.position.z);
        }
    }
}