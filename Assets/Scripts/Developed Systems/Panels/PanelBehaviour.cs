using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIElementsSystem
{
    [RequireComponent(typeof(Panel))]
    public abstract class PanelBehaviour : MonoBehaviour
    {
        public Panel panel { get; private set; }
        public int panelID => gameObject.GetInstanceID();

        public PanelState panelState => panel.panelState;


        protected virtual void Awake()
        {
            panel = GetComponent<Panel>();
        }


        protected virtual void OnEnable()
        {
            panel.OnStateChanged += OnStateChanged;
        }

        protected virtual void OnDisable()
        {
            panel.OnStateChanged -= OnStateChanged;
        }


        public void SetState(PanelState value) => panel.SetState(value);

        public void SetOn() => panel.SetState(PanelState.On);
        public void SetOff() => panel.SetState(PanelState.Off);
        public void SetMoving() => panel.SetState(PanelState.Moving);



        private void OnStateChanged()
        {
            switch (panelState)
            {
                case PanelState.On:
                    OnSetOn();
                    return;

                default:
                case PanelState.Off:
                    OnSetOff();
                    return;

                case PanelState.Moving:
                    OnSetMoving();
                    return;
            }
        }


        protected virtual void OnSetOn() { }
        protected virtual void OnSetOff() { }
        protected virtual void OnSetMoving() { }
    }
}