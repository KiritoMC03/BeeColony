using System;
using System.Collections.Generic;
using BeeColonyCore.Resources;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace BeeColonyCore.Buildings
{
    public class Warehouse : MonoBehaviourBase
    {
        public UnityEvent OnPollenCountChange;
        public UnityEvent OnCombsCountChange;
        
        private List<Pollen> _pollen = new List<Pollen>();
        private List<Comb> _combs = new List<Comb>();

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

        public int GetPollenCount()
        {
            return _pollen.Count;
        }

        public int GetCombsCount()
        {
            return _combs.Count;
        }

        public Pollen ExtractPollen()
        {
            var pollen = _pollen[_pollen.Count - 1];
            _pollen.Remove(pollen);
            return pollen;
        }

        public Comb ExtractComb()
        {
            var comb = _combs[_combs.Count - 1];
            _combs.Remove(comb);
            return comb;
        }

        private void AddPollen(Pollen pollen)
        {
            _pollen.Add(pollen);
            OnPollenCountChange?.Invoke();
        }
        

        private void AddComb(Comb comb)
        {
            _combs.Add(comb);
            OnCombsCountChange?.Invoke();
            Debug.Log("A!");
        }
    }
}