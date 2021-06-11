using UnityEngine;

namespace BeeColony.Core.Resources
{
    public class Pollen : Resource
    {
        public AvailableType Type;
        
        public Pollen(AvailableType type)
        {
            Type = type;
        }

        public enum AvailableType
        {
            Flower
        }
    }
}