using System;
using System.Collections.Generic;
using BeeColonyCore.Buildings.StorageDepartments;
using BeeColonyCore.Resources;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Random = UnityEngine.Random;

namespace BeeColonyCore.Buildings
{
    public class Warehouse : MonoBehaviourBase
    {
        public UnityEvent OnPollenCountChange;
        public UnityEvent OnCombsCountChange;
        
        public List<Comb> _combStorage = new List<Comb>();
        public List<Pollen> _pollenStorage = new List<Pollen>();

        private void Awake()
        {
            _combStorage = new List<Comb>();
            _pollenStorage = new List<Pollen>();
        }

        public void Add(Resource resource)
        {
            if (resource is Pollen pollen)
            {
                AddPollen(pollen);
            }
            else if (resource is Comb comb)
            {
                AddComb(comb);
            }
        }

        private void AddPollen(Pollen pollen)
        {
            foreach (var currentPollen in _pollenStorage)
            {
                if (pollen.Type != currentPollen.Type) continue;
                Debug.Log($"Pre: {currentPollen.Type} - {currentPollen.Value}");
                currentPollen.Increase(pollen.Value);
                Debug.Log($"Post: {currentPollen.Type} - {currentPollen.Value}");
                OnPollenCountChange?.Invoke();
                return;
            }

            CreateStorageDepartment(_pollenStorage, pollen);
        }
        
        private void AddComb(Comb comb)
        {
            foreach (var currentComb in _combStorage)
            {
                if (comb.Type != currentComb.Type) continue;
                Debug.Log($"PreComb: {currentComb.Type} - {currentComb.Value}");
                currentComb.Increase(comb.Value);
                Debug.Log($"PostComb: {currentComb.Type} - {currentComb.Value}");
                OnCombsCountChange?.Invoke();
                return;
            }

            CreateStorageDepartment(_combStorage, comb);
        }

        private void CreateStorageDepartment<ResourceType>(List<ResourceType> storage, ResourceType resource)
        {
            storage.Add(resource);
        }

        public Pollen ExtractNextPollen(int value)
        {
            if (_pollenStorage.Count == 0) return new Pollen();
            
            var pollenIndex = Random.Range(0, _pollenStorage.Count - 1);
            return _pollenStorage[pollenIndex].Decrease<Pollen>(value);
        }

        public int GetCombsCount(Comb.AvailableType type)
        {
            foreach (var comb in _combStorage)
            {
                if (comb.Type == type)
                {
                    return comb.Value;
                }
            }

            return 0;
        }
    }
}