// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.ScriptableObjects.Sets
{
    public abstract class RuntimeSet<T> : ScriptableObject, IEnumerable<T>
    {
        protected List<T> items = new List<T>();

        public T[] allItems => items.ToArray();
        public T this[int key] => items[key];
        public int count => items.Count;


        public void Add(T item)
        {
            if (!items.Contains(item))
                items.Add(item);
        }

        public void Remove(T item)
        {
            if (items.Contains(item))
                items.Remove(item);
        }


        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }
    }
}