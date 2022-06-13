using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.PrefabPool
{
    public interface IPrefabItem
    {
        GameObject clone { get; }
        bool inUse { get; }

        void SetName(string name = "");
        void ToggleInUse(bool value);
    }
}