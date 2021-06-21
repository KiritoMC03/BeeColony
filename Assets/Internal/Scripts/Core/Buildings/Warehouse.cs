﻿using System.Collections.Generic;
using BeeColonyCore.Resources;
using UnityEngine.Events;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColonyCore.Buildings
{
    public class Warehouse : MonoBehaviourBase
    {
        public UnityEvent OnPollenCountChange;
        public UnityEvent OnCombsCountChange;
        
        private List<Comb> _combStorage = new List<Comb>();
        private List<Pollen> _pollenStorage = new List<Pollen>();

        private void Awake()
        {
            _combStorage = new List<Comb>();
            _pollenStorage = new List<Pollen>();
        }

        public void Add(Product product)
        {
            if (product is Pollen pollen)
            {
                Send(_pollenStorage, pollen);
            }
            else if (product is Comb comb)
            {
                Send(_combStorage, comb);
            }
        }

        public Pollen ExtractNextPollen(int value)
        {
            if (_pollenStorage.Count == 0) return new Pollen();
            
            var pollenIndex = Random.Range(0, _pollenStorage.Count - 1);
            var temp = _pollenStorage[pollenIndex].Decrease<Pollen>(value);
            return temp;
        }

        public int GetCombsCount(Product.AvailableType type)
        {
            return GetCount(type, _combStorage);
        }

        public int GetPollenCount(Product.AvailableType type)
        {
            return GetCount(type, _pollenStorage);
        }

        private int GetCount<TProduct>(Product.AvailableType type, List<TProduct> storage)
            where TProduct : Product
        {
            foreach (var product in storage)
            {
                if (product.Type == type)
                {
                    return product.Value;
                }
            }

            return 0;
        }

        private void Send<TProduct>(List<TProduct> storage, TProduct product)
            where TProduct : Product
        {
            foreach (var currentProduct in storage)
            {
                if (product.Type != currentProduct.Type) continue;
                currentProduct.Increase(product.Value);
                OnPollenCountChange?.Invoke();
                return;
            }

            CreateStorageDepartment(storage, product);
        }

        private void CreateStorageDepartment<ResourceType>(List<ResourceType> storage, ResourceType resource)
        {
            storage.Add(resource);
            OnCombsCountChange?.Invoke();
        }
    }
}