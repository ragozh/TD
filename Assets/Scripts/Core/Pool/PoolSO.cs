using System.Collections.Generic;
using TD.Factory;
using UnityEngine;

namespace TD.Pool
{
    public abstract class PoolSO<T> : ScriptableObject, IPool<T>
    {
        protected readonly Queue<T> Available = new Queue<T>();
        public abstract IFactory<T> Factory { get; set; }        
		protected bool HasBeenPrewarmed { get; set; }
        protected virtual T Create() => Factory.Create();
        public virtual void Prewarm(int amount)
        {
            if (HasBeenPrewarmed)
            {
                Debug.LogWarning($"Pool {name} has already been prewarmed.");
                return;
            }
            for (int i = 0; i < amount; i++)
            {
                Available.Enqueue(Create());
            }
            HasBeenPrewarmed = true;
        }
        public virtual T Request()
        {
            return Available.Count > 0 ? Available.Dequeue() : Create();
        }
        public virtual IEnumerable<T> Request(int amount = 1)
        {
            List<T> results = new List<T>(amount);
            for (int i = 0; i < amount; i++)
            {
                results.Add(Request());
            }
            return results;
        }
        public virtual void Return(T obj)
        {
            Available.Enqueue(obj);
        }
        public virtual void Return(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Return(item);
            }
        }

		public virtual void OnDisable()
		{
			Available.Clear();
			HasBeenPrewarmed = false;
		}
    }
}