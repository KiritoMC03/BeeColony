using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ObjectPool
{
    public class ObjectPooler : MonoBehaviourBase
    {
        internal static ObjectPooler Instance;
        [SerializeField] private List<ObjectInfo> ObjectsInfo;

        private Dictionary<ObjectInfo.ObjectType, Pool> _pools;
        private GameObject _emptyGameObject;
        private GameObject _tempContainer;
        private GameObject _tempStartGameObject;
        private GameObject _tempInstantiateGameObject;

        [Serializable]
        public struct ObjectInfo
        {
            public enum ObjectType
            {
                Worker,
                Guardian,
                Bear
            }
            public ObjectType Type;
            [Header("Require IPooledObject component.")]
            public GameObject Prefab;
            public int StartCount;
        }

        private void Awake()
        {
            _emptyGameObject = new GameObject();

            if (Instance == null)
            {
                Instance = this;
            }

            InitPool();
        }

        private void InitPool()
        {
            _pools = new Dictionary<ObjectInfo.ObjectType, Pool>();

            foreach (var obj in ObjectsInfo)
            {
                _tempContainer = Instantiate(_emptyGameObject, transform, false);
                _tempContainer.name = obj.Type.ToString() + "_Pool";

                _pools[obj.Type] = new Pool(_tempContainer.transform);

                for (int i = 0; i < obj.StartCount; i++)
                {
                    _tempStartGameObject = InstantiateObject(obj.Type, _tempContainer.transform);
                    _pools[obj.Type].objects.Enqueue(_tempStartGameObject);
                }
            }
            Destroy(_emptyGameObject);
        }

        private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent)
        {
            _tempInstantiateGameObject = Instantiate(ObjectsInfo.Find(elem => elem.Type == type).Prefab, parent);
            _tempInstantiateGameObject.SetActive(false);
            return _tempInstantiateGameObject;
        }

        public GameObject GetObject(ObjectInfo.ObjectType type)
        {
            var obj = (_pools[type].objects.Count > 0) ?
                _pools[type].objects.Dequeue() : InstantiateObject(type, _pools[type].container);

            obj.SetActive(true);
            return obj;
        }

        public void DestroyObject(GameObject obj)
        {
            _pools[obj.GetInterfaceComponent<IPooledObject>().Type].objects.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}