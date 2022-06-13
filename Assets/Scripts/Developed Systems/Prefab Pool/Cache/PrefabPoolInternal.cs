using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Developed.PrefabPool
{
    /// <summary>
    /// C# style prefab pool
    /// </summary>
    public sealed class PrefabPoolInternal : IPrefabPool
    {
        private GameObject prefab;
        private Transform parent;

        private Dictionary<int, IPrefabItem> allCached = new Dictionary<int, IPrefabItem>();


        public PrefabPoolInternal(GameObject prefab, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;
        }


        public void Preload(int amount = 1)
        {
            if (amount <= 0)
                return;

            for (int i = 0; i < amount; i++)
                CreateNew();

            FreeAll();
        }

        public GameObject GetNew(string itemName = "")
        {
            var newPrefabItem = GetNewItem();

            newPrefabItem.SetName(itemName);
            newPrefabItem.ToggleInUse(true);

            return newPrefabItem.clone;
        }


        public bool ContainsInUse(GameObject gameObject)
        {
            var instanceID = gameObject.GetInstanceID();

            return allCached.ContainsKey(instanceID) ? allCached[instanceID].inUse : false;
        }


        public void SetFree(GameObject gameObject)
        {
            var instanceID = gameObject.GetInstanceID();

            if (allCached.ContainsKey(instanceID) && allCached[instanceID].inUse)
                allCached[instanceID].ToggleInUse(false);
        }

        public void FreeAll()
        {
            foreach (IPrefabItem item in allCached.Values)
                item.ToggleInUse(false);
        }



        private IPrefabItem GetNewItem()
        {
            if (GetFirstPassive(out var result))
                return result;

            return CreateNew();
        }

        private IPrefabItem CreateNew()
        {
            var newObject = GameObject.Instantiate(prefab, parent);

            var objectItem = new PrefabItem(newObject);
            allCached.Add(newObject.GetInstanceID(), objectItem);

            return objectItem;
        }

        private bool GetFirstPassive(out IPrefabItem result)
        {
            result = allCached.Values.FirstOrDefault(t => !t.inUse);
            return result != null;
        }
    }
}