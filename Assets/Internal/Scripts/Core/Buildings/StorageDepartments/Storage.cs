using System.Collections.Generic;
using Utils;

namespace BeeColonyCore.Buildings.StorageDepartments
{
    public abstract class Storage : MonoBehaviourBase
    {
        public List<Resource> Value { get; private set; }
    }
}