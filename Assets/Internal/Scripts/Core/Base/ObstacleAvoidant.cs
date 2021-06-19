using UnityEngine;
using Utils;

namespace BeeColonyCore
{
    public class ObstacleAvoidant : MonoBehaviourBase
    {
        public static void Avoid(Rigidbody2D current, Transform target, float force)
        {
            Debug.Log("Avoid");
            var direction = (Vector2)(target.transform.position - current.transform.position).normalized;
            current.AddForce(direction * force * Time.fixedDeltaTime);
        }
    }
}