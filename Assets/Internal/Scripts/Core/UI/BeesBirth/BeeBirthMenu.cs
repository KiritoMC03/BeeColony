using System;
using BeeColony.Core.Bees.Base;
using BeeColony.Core.Spawners;
using UnityEngine;
using Utils;

namespace BeeColony.Core.UI.Birth
{
    public class BeeBirthMenu : MonoBehaviourBase
    {
        [SerializeField] private Bee[] bees;
        [SerializeField] private Transform birthZone;
        [SerializeField] private BeeBirthElement beeBirthPrefab;
        [SerializeField] private BeeSpawner beeSpawner;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            for (int i = 0; i < bees.Length; i++)
            {
                var newBee = Instantiate(beeBirthPrefab, birthZone);
                Debug.Log($"{i} - bee: {bees[i]}");
                
                Debug.Log($"Generate: {bees[i].Type}");
                newBee.Construct(bees[i], beeSpawner);
            }
        }
    }
}