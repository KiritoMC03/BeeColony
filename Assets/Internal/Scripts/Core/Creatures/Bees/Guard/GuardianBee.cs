using System;
using BeeColonyCore.Bees;
using Internal.Scripts.Core.Creatures.Enemies;
using UnityEngine;

namespace BeeColonyCore.Bees
{
    public class GuardianBee : Bee
    {
        [Header("Guardian Bee")]
        [SerializeField] private MovementAroundHive movementAroundHive;
        [SerializeField] private SeenEnemyCache seenEnemyCache;
        [SerializeField] private BeeAttack beeAttack;

        private Enemy _targetEnemy;

        protected override void Awake_Work()
        {
            base.Awake_Work();
            OnHiveSet.AddListener(() => movementAroundHive.SetHive(parentHive));
            seenEnemyCache.OnCached.AddListener(SetCachedEnemy);
        }

        protected override void FixedUpdate_Work()
        {
            if (beeAttack.IsAttackingNow)
            {
                motor.Stop();
            }
            if (!movementAroundHive.IsEnable)
            {
                if (_targetEnemy == null)
                {
                    movementAroundHive.Enable();
                    return;
                }
                TryMoveTo(_targetEnemy.Position);
            }
        }

        private void SetCachedEnemy()
        {
            movementAroundHive.Disable();
            _targetEnemy = seenEnemyCache.Extract();
        }

        protected override void OnTriggerEnter2D_Work(Collider2D other)
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                beeAttack.StartAttack(enemy);
            }
        }

        protected override void OnTriggerExit2D_Work(Collider2D other)
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                beeAttack.EndAttack(enemy);
            }
        }
    }
}