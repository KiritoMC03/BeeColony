﻿using System;
using BeeColony.Core.Buildings;
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
            warehouse.OnHoneycombsCountChange.AddListener(SetResourcesTexts);
        }

        private void OnDisable()
        {
            warehouse.OnHoneycombsCountChange.RemoveAllListeners();
        }

        private void SetResourcesTexts()
        {
            honeycombValueText.text = warehouse.GetHoneycombsCount().ToString();
        }
    }
}