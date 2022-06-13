using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Developed.ScriptableObjects.Variables
{
    internal interface IVariableSync
    {
        void ResetRuntime();
        void SynchronizeInitial();
        void InvokeOnValueChanged();
    }
}