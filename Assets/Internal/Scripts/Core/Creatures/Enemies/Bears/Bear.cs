using System;
using BeeColony.Core.Buildings;
using ObjectPool;
using UnityEngine;
using Utils;
using PooledObjectType = ObjectPool.ObjectPooler.ObjectInfo.ObjectType;

namespace BeeColony.Core.Enemies
{
    public class Bear : MonoBehaviourBase, IPooledObject
    {
        public PooledObjectType Type => type;
        [SerializeField] private PooledObjectType type = PooledObjectType.Bear;
        
        [SerializeField] private BearMotor motor;
        [SerializeField] private BearRadar radar;

        private Hive _primaryHive;
        private Hive _tempTargetHive;
        private bool _seePrimaryHive = false;
        private bool _seeTempTargetHive = false;

        private void Start()
        {
            radar.OnHiveSeen.AddListener(GetTargetHiveFromRadar);
        }

        private void FixedUpdate()
        {
            if (_seeTempTargetHive)
            {
                motor.PhysicalMoveTo(_tempTargetHive.Position);
            }
            else if(_seePrimaryHive)
            {
                motor.PhysicalMoveTo(_primaryHive.Position);
            }
            else
            {
                motor.Stop();
            }
        }

        public void SetPrimaryHive(Hive hive)
        {
            _primaryHive = hive;
            _seePrimaryHive = true;
        }

        private void GetTargetHiveFromRadar()
        {
            _tempTargetHive = radar.SeenHive;
        }
    }
}