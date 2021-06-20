using UnityEngine;

namespace BeeColonyCore.Resources
{
    public class Comb : Resource
    {
        public AvailableType Type { get; private set; }

        public Comb(AvailableType type)
        {
            Type = type;
        }

        public Comb(AvailableType type, int value)
        {
            Type = type;
            Value = value;
        }
        
        public enum AvailableType
        {
            Honey,
            Icy,
            Night,
            Bloody,
            Steel
        }
    }
}