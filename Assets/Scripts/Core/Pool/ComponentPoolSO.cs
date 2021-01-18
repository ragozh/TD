using UnityEngine;

namespace TD.Pool
{
    public abstract class ComponentPoolSO<T> : PoolSO<T> where T : Component
    {
        private Transform _poolRoot;
        private Transform _parent;
        private Transform PoolRoot
        {
            get
            {
                if (_poolRoot == null)
                {
                    _poolRoot = new GameObject(name).transform;
                    _poolRoot.SetParent(_parent);
                }
                return _poolRoot;
            }
        }
        public void SetParent(Transform parent)
        {
            _parent = parent;
            PoolRoot.SetParent(_parent);
        }
        public override T Request()
        {
            T obj = base.Request();
            obj.gameObject.SetActive(true);
            return obj;
        }
        public override void Return(T obj)
        {
            obj.transform.SetParent(PoolRoot.transform);
            obj.gameObject.SetActive(false);
            base.Return(obj);
        }
        protected override T Create()
        {
            T newObj = base.Create();
            newObj.transform.SetParent(PoolRoot);
            newObj.gameObject.SetActive(false);
            return newObj;
        }
		public override void OnDisable()
		{
			base.OnDisable();
			if (_poolRoot != null)
			{
#if UNITY_EDITOR
				DestroyImmediate(_poolRoot.gameObject);
#else
				Destroy(_poolRoot.gameObject);
#endif
			}
		}
    }
}