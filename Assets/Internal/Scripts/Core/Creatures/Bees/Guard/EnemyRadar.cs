using BeeColonyCore.Enemies;
using UnityEngine;
using Utils;

namespace BeeColonyCore.Bees
{
    public class EnemyRadar : MonoBehaviourBase
    {
        [SerializeField] private SeenEnemyCache seenEnemyCache;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log($"A");
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log($"B");
                seenEnemyCache.Add(enemy);
            }
        }
    }
}