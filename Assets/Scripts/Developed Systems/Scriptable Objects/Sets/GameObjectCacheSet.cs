using System.Linq;
using UnityEngine;

namespace Developed.ScriptableObjects.Sets
{
    [CreateAssetMenu(menuName = "Game Object Cache", order = 51)]
    public sealed class GameObjectRuntimeSet : RuntimeSet<GameObject>
    {
        public GameObject GetByInstanceID(int instanceID) => items.FirstOrDefault(item => item.GetInstanceID() == instanceID);
    }
}