using BeeColonyCore.Buildings;
using UnityEngine;

namespace BeeColonyCore.Enemies
{
    public class Bear : Enemy
    {
        [SerializeField] private BearMotor motor;
        [SerializeField] private BearRadar radar;
        [SerializeField] private BearRobber robber;

        private Hive _primaryHive;
        private Hive _tempTargetHive;
        private bool _seePrimaryHive = false;
        private bool _seeTempTargetHive = false;

        protected override void Start_Work()
        {
            radar.OnHiveSeen.AddListener(GetTargetHiveFromRadar);
        }

        protected override void FixedUpdate_Work()
        {
            if(robber.IsStealsNow)
            {
                motor.Stop();
            }
            else if (_seeTempTargetHive)
            {
                motor.PhysicalMoveTo(_tempTargetHive.Position);
            }
            else if(_seePrimaryHive)
            {
                motor.PhysicalMoveTo(_primaryHive.Position);
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