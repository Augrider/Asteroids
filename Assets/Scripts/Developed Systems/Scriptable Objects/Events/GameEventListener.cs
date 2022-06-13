using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Developed.ScriptableObjects.Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with.")]
        public GameEvent gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent response;


        void OnEnable()
        {
            gameEvent.Register(this);
        }

        void OnDisable()
        {
            gameEvent.Unregister(this);
        }


        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}