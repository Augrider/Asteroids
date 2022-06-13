using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.PrefabPool
{
    /// <summary>
    /// Pool component that can store and provide objects created from multiple types of prefabs
    /// </summary>
    public class MultiPrefabPool : MonoBehaviour, IPrefabPoolExternal
    {
        [SerializeField] private Transform parent;

        private Dictionary<GameObject, IPrefabPool> prefabPools = new Dictionary<GameObject, IPrefabPool>();


        public void Preload(GameObject prefab, int amount = 1)
        {
            GetPrefabPool(prefab).Preload(amount);
        }

        public GameObject GetNew(GameObject prefab, string itemName = "")
        {
            return GetPrefabPool(prefab).GetNew(itemName);
        }


        public bool ContainsInUse(GameObject gameObject)
        {
            foreach (IPrefabPool pool in prefabPools.Values)
                if (pool.ContainsInUse(gameObject))
                    return true;

            return false;
        }


        public void SetFree(GameObject gameObject)
        {
            foreach (IPrefabPool pool in prefabPools.Values)
                pool.SetFree(gameObject);
        }

        public void FreeAll()
        {
            foreach (IPrefabPool pool in prefabPools.Values)
                pool.FreeAll();
        }

        /// <summary>
        /// Remove pool storing this prefab clones. Will not destroy objects itself
        /// </summary>
        /// <param name="prefab">Reference to original prefab</param>
        public void RemovePool(GameObject prefab)
        {
            if (prefabPools.ContainsKey(prefab))
                prefabPools.Remove(prefab);
        }

        /// <summary>
        /// Remove pool storing this prefab clones. Will not destroy objects itself
        /// </summary>
        public void ClearPools()
        {
            prefabPools.Clear();
        }



        private IPrefabPool GetPrefabPool(GameObject prefab)
        {
            if (prefabPools.ContainsKey(prefab))
                return prefabPools[prefab];

            var prefabPool = new PrefabPoolInternal(prefab, parent ? parent : transform);
            prefabPools.Add(prefab, prefabPool);

            return prefabPool;
        }
    }
}