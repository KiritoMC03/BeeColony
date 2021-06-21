using System;
using System.Collections;
using BeeColonyCore.Buildings;
using UnityEngine;
using Utils;

namespace BeeColonyCore.Enemies
{
    public class BearRobber : MonoBehaviourBase
    {
        public bool IsStealsNow { get; private set; } = false;

        [SerializeField] private int volume = 3;
        [SerializeField] private float stealDelay = 2;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var hive = other.gameObject.GetComponent<Hive>();
            if (hive != null)
            {
                StartCoroutine(StealRoutine(hive));
                IsStealsNow = true;
            }
        }

        private IEnumerator StealRoutine(Hive hive)
        {
            while (true)
            {
                hive.PullOutComb(volume);
                yield return new WaitForSeconds(stealDelay);
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}