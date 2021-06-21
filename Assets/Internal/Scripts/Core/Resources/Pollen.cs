using UnityEngine;

namespace BeeColonyCore.Resources
{
    public class Pollen : Product
    {
        public Pollen() : base()
        {
            
        }
        
        public Pollen(AvailableType type, int value) : base(type, value)
        {
        }
    }
}