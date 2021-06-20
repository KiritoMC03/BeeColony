using System;
using BeeColonyCore.Buildings;
using BeeColonyCore.Resources;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Internal.Scripts.Core.Statistics
{
    public class ResourceStats : MonoBehaviourBase
    {
        [Header("Resources:")]
        [SerializeField] private Warehouse warehouse;
        [SerializeField] private Text honeycombValueText;

        private void OnEnable()
        {
            SetResourcesTexts();
            warehouse.OnCombsCountChange.AddListener(SetResourcesTexts);
        }

        private void OnDisable()
        {
            warehouse.OnCombsCountChange.RemoveAllListeners();
        }

        private void SetResourcesTexts()
        {
            honeycombValueText.text = warehouse.GetCombsCount(Comb.AvailableType.Honey).ToString();
        }
    }
}