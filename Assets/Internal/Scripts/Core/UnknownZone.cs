using BeeColonyCore.Buildings;
using UnityEngine;
using Utils;

namespace BeeColonyCore.Bees
{
    public class UnknownZone : MonoBehaviourBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Bee>() != null)
            {
                Destroy(gameObject);
            }
        }
    }
}