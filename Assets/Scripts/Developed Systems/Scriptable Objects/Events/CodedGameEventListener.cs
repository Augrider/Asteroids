using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.ScriptableObjects.Events
{
    [System.Serializable]
    public class CodedGameEventListener : IGameEventListener
    {
        [SerializeField] private GameEvent gameEvent;
        private Action action;


        public void OnEnable(Action action)
        {
            gameEvent?.Register(this);
            this.action = action;
        }

        public void OnDisable()
        {
            gameEvent?.Unregister(this);
            this.action = null;
        }


        public void OnEventRaised()
        {
            action?.Invoke();
        }
    }
}