using BeeColonyCore.Buildings;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColonyCore.Enemies
{
    public class BearRadar : MonoBehaviourBase
    {
        public UnityEvent OnHiveSeen;
        
        public Hive SeenHive { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var hive = other.GetComponent<Hive>();
            if (hive != null)
            {
                SeenHive = hive;
                OnHiveSeen?.Invoke();
            }
        }
    }
}