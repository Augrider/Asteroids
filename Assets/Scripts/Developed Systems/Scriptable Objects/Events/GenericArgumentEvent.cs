using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.ScriptableObjects.Events
{
    /// <summary>
    /// Base class for events with 1 argument
    /// </summary>
    public abstract class GenericArgumentEvent<T> : ScriptableObject
    {
        protected Action<T> actions;


        public virtual void Subscribe(Action<T> action) => actions += action;
        public virtual void Unsubscribe(Action<T> action) => actions -= action;


        public virtual void RaiseEvent(T argument)
        {
            actions?.Invoke(argument);
        }
    }


    /// <summary>
    /// Base class for events with 2 arguments
    /// </summary>
    public abstract class GenericArgumentEvent<T, Y> : ScriptableObject
    {
        protected Action<T, Y> actions;


        public virtual void Subscribe(Action<T, Y> action) => actions += action;
        public virtual void Unsubscribe(Action<T, Y> action) => actions -= action;


        public virtual void RaiseEvent(T arg0, Y arg1)
        {
            actions?.Invoke(arg0, arg1);
        }
    }


    /// <summary>
    /// Base class for events with 3 arguments
    /// </summary>
    public abstract class GenericArgumentEvent<T, Y, U> : ScriptableObject
    {
        protected Action<T, Y, U> actions;


        public virtual void Subscribe(Action<T, Y, U> action) => actions += action;
        public virtual void Unsubscribe(Action<T, Y, U> action) => actions -= action;


        public virtual void RaiseEvent(T arg0, Y arg1, U arg2)
        {
            actions?.Invoke(arg0, arg1, arg2);
        }
    }
}