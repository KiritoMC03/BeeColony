using UnityEngine;
using Utils;

namespace BeeColonyCore.Buildings
{
    public class Hive : MonoBehaviourBase
    {
        public static Hive Instance;
        public Vector3 Position => _transform.position;

        [SerializeField] private Warehouse warehouse;
        
        private Transform _transform;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            Instance = this;
            _transform = transform;
        }

        public void AcceptResource(Resource resource)
        {
            warehouse.Add(resource);
        }
    }
}