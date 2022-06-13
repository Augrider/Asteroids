using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Developed.PrefabPool
{
    /// <summary>
    /// Pool component for prefabs
    /// </summary>
    public sealed class PrefabPool : MonoBehaviour, IPrefabPool
    {
        [SerializeField] private GameObject prefab;

        [SerializeField] private Transform parent;

        /// <summary>
        /// Amount of copies loaded at the start of the game
        /// </summary>
        [SerializeField] private int preloadAmount = 0;

        private IPrefabPool internalPool;


        void Awake()
        {
            this.internalPool = new PrefabPoolInternal(prefab, parent ? parent : transform);
        }

        // Start is called before the first frame update
        void Start()
        {
            Preload(preloadAmount);
        }

        /// <summary>
        /// Load an amount of unused items
        /// </summary>
        /// <param name="amount">Amount of items</param>
        public void Preload(int amount = 1)
        {
            internalPool.Preload(amount);
        }


        /// <summary>
        /// Get new or available prefab gameObject
        /// </summary>
        /// <param name="itemName">Optional name for object</param>
        public GameObject GetNew(string itemName = "")
        {
            return internalPool.GetNew(itemName);
        }


        /// <summary>
        /// Check if prefab is currently in use
        /// </summary>
        /// <param name="instanceID">GameObject Instance ID</param>
        /// <returns>true if prefab with the same ID found and in use</returns>
        public bool ContainsInUse(GameObject gameObject)
        {
            return internalPool.ContainsInUse(gameObject);
        }


        /// <summary>
        /// Free prefab from use
        /// </summary>
        /// <param name="instanceID">GameObject Instance ID</param>
        public void SetFree(GameObject gameObject)
        {
            internalPool.SetFree(gameObject);
        }

        /// <summary>
        /// Free all prefabs from use
        /// </summary>
        public void FreeAll()
        {
            internalPool.FreeAll();
        }
    }
}