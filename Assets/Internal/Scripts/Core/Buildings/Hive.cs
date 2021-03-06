using BeeColonyCore.Resources;
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

        public void AcceptResource(Product product)
        {
            warehouse.Add(product);
        }

        public Comb PullOutComb(int value)
        {
            return warehouse.ExtractNextComb(value);
        }
    }
}