using UnityEngine;
using Utils;

namespace BeeColony.Core.Bee
{
    public class Bee : MonoBehaviourBase
    {
        [SerializeField] private ParticleSystem pollen;

        private void Start()
        {
            pollen.Stop();
        }

        /*
        private void OnTriggerEnter2D(Collider other)
        {
            Debug.Log("cond: " + other.GetComponent<Flower>() != null);
            if (other.GetComponent<Flower>() != null)
            {
                pollen.Play();
            }
        }
        */

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("trigger");

            if (other.GetComponent<Hive>() != null)
            {
                Debug.Log("cond: " + other.GetComponent<Hive>() != null);
                pollen.Stop();
            }

            if (other.GetComponent<Flower>() != null)
            {
                pollen.Play();
            }
        }
    }
}