using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Pool
    {
        internal Transform container { get; set; }
        internal Queue<GameObject> objects;

        public Pool(Transform container)
        {
            this.container = container;
            objects = new Queue<GameObject>();
        }
    }
}