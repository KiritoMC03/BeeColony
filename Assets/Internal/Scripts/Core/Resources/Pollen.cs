using UnityEngine;

namespace BeeColonyCore.Resources
{
    public class Pollen : Resource
    {
        public AvailableType Type;
        
        public Pollen()
        {
            Type = AvailableType.Flower;
            Value = 0;
        }
        
        public Pollen(AvailableType type)
        {
            Type = type;
        }

        public Pollen(Pollen.AvailableType type, int value)
        {
            Type = type;
            Value = value;
        }

        public enum AvailableType
        {
            Flower,
            Night,
            Icy,
            Bloody,
            Steel
        }
    }
}