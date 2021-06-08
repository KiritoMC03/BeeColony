using BeeColony.Core.Bees.Base;
using UnityEngine;

namespace BeeColony.Core.Bees.Guard
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