using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Developed.PrefabPool
{
    internal class PrefabItem : IPrefabItem
    {
        public bool inUse { get; private set; }
        public GameObject clone { get; private set; }

        /// <summary>
        /// Get InstanceID of item in storage
        /// </summary>
        public int itemID => clone.GetInstanceID();


        public PrefabItem(GameObject prefab)
        {
            this.clone = prefab;
            this.inUse = false;

            ToggleInUse(false);
        }


        public void ToggleInUse(bool value)
        {
            inUse = value;
            clone.SetActive(value);
        }

        public void SetName(string name = "")
        {
            if (!string.IsNullOrEmpty(name))
                clone.name = name;
        }


        public override string ToString()
        {
            return string.Format("Prefab {0}, in use {1}", clone, inUse);
        }
    }
}