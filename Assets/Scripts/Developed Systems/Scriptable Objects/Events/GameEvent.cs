using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.ScriptableObjects.Events
{
    [CreateAssetMenu(menuName = "Game Event", order = 51)]
    public class GameEvent : ScriptableObject
    {
        private static List<IGameEventListener> listeners = new List<IGameEventListener>();


        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }


        public void Register(IGameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void Unregister(IGameEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}