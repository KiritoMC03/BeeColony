﻿using System.Collections;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColony.Core.Bees.Guard
{
    public class MovementAroundHive : MonoBehaviourBase
    {
        [SerializeField] private float radius = 3f;
        [SerializeField] private Motor motor;
        [SerializeField] private float checkPositionPeriod = 3f;

        private Hive _hive;
        private Vector2 _target;

        private void OnEnable()
        {
            _target = FindNextPosition();
            StartCoroutine(CheckPositionRoutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void FixedUpdate()
        {
            motor.PhysicalMoveTo(_target);
        }

        public void SetHive(Hive hive)
        {
            _hive = hive;
        }

        private Vector2 FindNextPosition()
        {
            if (_hive == null)
            {
                return Random.insideUnitCircle * radius;
            }
            return Random.insideUnitCircle * radius + (Vector2)_hive.transform.position;
        }

        private IEnumerator CheckPositionRoutine()
        {
            while (true)
            {
                if (Mathf.Round(transform.position.x) == Mathf.Round(_target.x) ||
                    Mathf.Round(transform.position.y) == Mathf.Round(_target.y))
                {
                    _target = FindNextPosition();
                }

                yield return new WaitForSeconds(checkPositionPeriod);
            }
        }
    }
}