using System;
using System.Collections;
using BeeColony.Core.Resources;
using UnityEngine;
using Utils;

namespace BeeColony.Core.Buildings
{
    public class PollenProcessor : MonoBehaviourBase
    {
        [SerializeField] private Warehouse warehouse;
        [SerializeField] private float processDelay = 5f;

        private void OnEnable()
        {
            StartCoroutine(ProcessRoutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator ProcessRoutine()
        {
            while (true)
            {
                if (warehouse.GetPollenCount() > 0)
                {
                    warehouse.Add(Process(warehouse.ExtractPollen()));
                }
                yield return new WaitForSeconds(processDelay);
            }
        }

        private Comb Process(Pollen pollen)
        {
            if (pollen.Type == Pollen.AvailableType.Flower)
            {
                return new Comb(Comb.AvailableType.Honey);
            }

            throw new Exception("Target comb type not found.");
        }
    }
}