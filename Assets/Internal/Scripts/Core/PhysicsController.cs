using System;
using UnityEngine;
using Utils;

namespace Internal.Scripts.Core
{
    public class PhysicsController : MonoBehaviourBase
    {
        private void Awake()
        {
            Physics.autoSimulation = false;
        }
    }
}