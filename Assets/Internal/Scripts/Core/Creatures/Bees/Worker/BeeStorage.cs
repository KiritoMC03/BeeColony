using System;
using UnityEngine;
using Utils;

namespace BeeColonyCore.Bees
{
    public class BeeStorage : MonoBehaviourBase
    {
        public event Action OnStorageChange;
        
        public bool IsEmpty => _product == null;
        public Product _product;

        public void Add(Product product)
        {
            if (_product == null)
            {
                _product = product;
                OnStorageChange?.Invoke();
            }
        }

        public Product Extract()
        {
            var temp = _product;
            _product = null;
            OnStorageChange?.Invoke();

            return temp;
        }
    }
}