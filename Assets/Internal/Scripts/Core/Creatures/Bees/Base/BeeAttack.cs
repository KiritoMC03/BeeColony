using System.Collections;
using System.Collections.Generic;
using BeeColonyCore.Enemies;
using UnityEngine;
using Utils;

namespace BeeColonyCore.Bees
{
    public class BeeAttack : MonoBehaviourBase
    {
        public bool IsAttackingNow => _enemies.Count > 0;
        
        [SerializeField] private int attackPower = 1;
        [SerializeField] private float delay = 1f;
        private List<Enemy> _enemies;

        private void Awake()
        {
            _enemies = new List<Enemy>();
        }

        private void OnEnable()
        {
            StartCoroutine(DealDamageRoutine());
            OnEnable_Work();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            OnDisable_Work();
        }

        public virtual void StartAttack(Enemy enemy)
        {
            _enemies.Add(enemy);
        }
        public virtual void EndAttack(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public virtual IEnumerator DealDamageRoutine()
        {
            while (true)
            {
                for (var i = 0; i < _enemies.Count; i++)
                {
                    _enemies[i].AcceptDamage(attackPower);
                }
                yield return new WaitForSeconds(delay);
            }
        }
        
        protected virtual void OnEnable_Work() {}
        protected virtual void OnDisable_Work() {}
    }
}