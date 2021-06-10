using Internal.Scripts.Core.Creatures.Enemies;
using UnityEngine.Events;
using Utils;

namespace BeeColony.Core.Bees
{
    public class SeenEnemyCache : MonoBehaviourBase
    {
        public UnityEvent OnCached;
        public bool isCached = false;
        
        public Enemy _cachedEnemy;

        public void Add(Enemy enemy)
        {
            _cachedEnemy = enemy;
            isCached = true;
            OnCached?.Invoke();
        }

        public Enemy Extract()
        {
            isCached = false;
            var temp = _cachedEnemy;
            _cachedEnemy = null;
            return temp;
        }
    }
}