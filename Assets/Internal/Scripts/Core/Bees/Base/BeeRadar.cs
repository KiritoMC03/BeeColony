using System;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees.Base
{
    public class BeeRadar : MonoBehaviourBase
    {
        [SerializeField] private SeenFlowerCache seenFlowerCache;
        private Collider2D _collider;

        private void Awake()
        {
            InitFields();
            SetStartPreferences();
        }

        private void InitFields()
        {
            _collider = GetSafeComponent<Collider2D>();
        }

        private void SetStartPreferences()
        {
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var flower = other.GetComponent<Flower>();
            if (flower != null)
            {
                Debug.Log("flower: " + flower == null + " or not");
                seenFlowerCache.AddFlower(flower);
            }
        }
    }
}