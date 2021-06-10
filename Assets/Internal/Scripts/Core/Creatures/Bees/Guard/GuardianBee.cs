using BeeColony.Core.Bees;
using UnityEngine;

namespace BeeColony.Core.Bees
{
    public class GuardianBee : Bee
    {
        [Header("Guardian Bee")]
        [SerializeField] private MovementAroundHive movementAroundHive;

        protected override void Awake_Work()
        {
            base.Awake_Work();
            OnHiveSet.AddListener(() => movementAroundHive.SetHive(parentHive));
        }
    }
}