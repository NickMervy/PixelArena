using UniRx.Toolkit;
using UnityEngine;

namespace Services
{
    public class ComponentPool : ObjectPool
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;

        protected ComponentPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        protected ComponentPool(GameObject prefab, Transform parent)
            : this(prefab)
        {
            _parent = parent;
        }

        protected override GameObject CreateInstance()
        {
            var obj = Object.Instantiate(_prefab);
            if(_parent != null)
                obj.transform.SetParent(_parent);

            return obj;
        }
    }
}