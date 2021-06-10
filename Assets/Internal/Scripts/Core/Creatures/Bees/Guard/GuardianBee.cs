using BeeColony.Core.Bees;
using Internal.Scripts.Core.Creatures.Enemies;
using UnityEngine;

namespace BeeColony.Core.Bees
{
    public class GuardianBee : Bee
    {
        [Header("Guardian Bee")]
        [SerializeField] private MovementAroundHive movementAroundHive;
        [SerializeField] private SeenEnemyCache seenEnemyCache;

        private Enemy _targetEnemy;

        protected override void Awake_Work()
        {
            base.Awake_Work();
            OnHiveSet.AddListener(() => movementAroundHive.SetHive(parentHive));
            seenEnemyCache.OnCached.AddListener(SetCachedEnemy);
        }

        protected override void FixedUpdate_Work()
        {
            if (!movementAroundHive.IsEnable)
            {
                if (_targetEnemy == null)
                {
                    movementAroundHive.Enable();
                    return;
                }
                motor.PhysicalMoveTo(_targetEnemy.Position);
            }
        }

        private void SetCachedEnemy()
        {
            movementAroundHive.Disable();
            _targetEnemy = seenEnemyCache.Extract();
        }
    }
}