using BeeColony.Core.Bees;
using BeeColony.Core.Spawners;
using UnityEngine;

namespace BeeColony.Core.UI.Birth
{
    public class BeesBirthMenu : Menu
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
                newBee.Construct(bees[i], beeSpawner);
            }
        }
    }
}