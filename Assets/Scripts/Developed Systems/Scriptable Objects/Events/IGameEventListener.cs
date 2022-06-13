using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.ScriptableObjects.Events
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
}
