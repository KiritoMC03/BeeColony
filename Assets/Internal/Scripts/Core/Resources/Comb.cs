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
        
        public enum AvailableType
        {
            Honey
        }
    }
}