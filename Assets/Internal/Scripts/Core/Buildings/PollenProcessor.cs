using System;
using System.Collections;
using BeeColonyCore.Resources;
using UnityEngine;
using Utils;

namespace BeeColonyCore.Buildings
{
    public class PollenProcessor : MonoBehaviourBase
    {
        [SerializeField] private Warehouse warehouse;
        [SerializeField] private float processDelay = 5f;
        [SerializeField] private int processingVolume = 5;

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
                warehouse.Add(Process(warehouse.ExtractNextPollen(processingVolume)));
                yield return new WaitForSeconds(processDelay);
            }
        }

        private Comb Process(Pollen pollen)
        {
            if (pollen.Type == Pollen.AvailableType.Flower)
            {
                return new Comb(Comb.AvailableType.Honey, 3);
            }

            throw new Exception("Target comb type not found.");
        }
    }
}