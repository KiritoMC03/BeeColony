using System;
using BeeColonyCore;
using BeeColonyCore.Buildings;
using BeeColonyCore.Resources;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Internal.Scripts.Core.Statistics
{
    public class ResourceStats : MonoBehaviourBase
    {
        [SerializeField] private Warehouse warehouse;
        
        [Header("Pollen:")]
        [SerializeField] private Text flowerPollenValue;
        
        [Header("Combs:")]
        [SerializeField] private Text honeyCombValue;

        private void OnEnable()
        {
            SetResourcesTexts();
            warehouse.OnCombsCountChange.AddListener(SetResourcesTexts);
            warehouse.OnPollenCountChange.AddListener(SetResourcesTexts);
        }

        private void OnDisable()
        {
            warehouse.OnCombsCountChange.RemoveAllListeners();
            warehouse.OnPollenCountChange.RemoveAllListeners();
        }

        private void SetResourcesTexts()
        {
            flowerPollenValue.text = warehouse.GetPollenCount(Pollen.AvailableType.Flower).ToString();
            honeyCombValue.text = warehouse.GetCombsCount(Comb.AvailableType.Flower).ToString();
        }
    }
}