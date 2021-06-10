﻿using BeeColony.Core.Buildings;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees
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