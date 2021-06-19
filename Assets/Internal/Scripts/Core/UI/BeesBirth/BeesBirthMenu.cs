using System;
using System.Text;
using BeeColonyCore.Bees;
using BeeColonyCore.Spawners;
using UnityEngine;
using UnityEngine.UI;

namespace BeeColonyCore.UI.Birth
{
    public class BeesBirthMenu : Menu
    {
        [SerializeField] private Bee[] bees;
        [SerializeField] private Transform birthZone;
        [SerializeField] private BeeBirthElement beeBirthPrefab;
        [SerializeField] private BeeSpawner beeSpawner;
        [SerializeField] private Text spawnTime;

        private const string SPAWN_TIME_TEXT = " секунда";

        private void Start()
        {
            Generate();
        }

        private void OnEnable()
        {
            spawnTime.text = beeSpawner.GetDelay() + SPAWN_TIME_TEXT;
        }

        private void Generate()
        {
            for (var i = 0; i < bees.Length; i++)
            {
                var newBee = Instantiate(beeBirthPrefab, birthZone);
                newBee.Construct(bees[i], beeSpawner);
            }
        }

        private void SetTexts()
        {
            spawnTime.text = beeSpawner.GetDelay() + SPAWN_TIME_TEXT;
        }
    }
}