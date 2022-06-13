using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.PrefabPool
{
    /// <summary>
    /// Interface for prefab pools that store reference inside
    /// </summary>
    public interface IPrefabPool
    {
        void Preload(int amount = 1);

        GameObject GetNew(string itemName = "");

        bool ContainsInUse(GameObject gameObject);

        void SetFree(GameObject gameObject);
        void FreeAll();
    }

    /// <summary>
    /// Interface for prefab pools that receive prefab reference externally
    /// </summary>
    /// <remarks>
    /// Pools with this interface must support different prefabs in one pool
    /// </remarks>
    public interface IPrefabPoolExternal
    {
        void Preload(GameObject prefab, int amount = 1);

        GameObject GetNew(GameObject prefab, string itemName = "");

        bool ContainsInUse(GameObject gameObject);

        void SetFree(GameObject gameObject);
        void FreeAll();
    }
}