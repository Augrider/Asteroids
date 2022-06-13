using System.Collections;
using System.Collections.Generic;
using Developed.Extentions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIElementsSystem
{
    public enum PanelState { On, Moving, Off };

    [RequireComponent(typeof(RectTransform))]
    public sealed class Panel : UIBehaviour
    {
        public RectTransform rectTransform { get; private set; }

        public Vector2 relativePosition => rectTransform.ScreenRelativePosition();
        public Vector2 absolutePosition => rectTransform.anchoredPosition;

        public PanelState panelState { get; private set; } = PanelState.Off;
        public event System.Action OnStateChanged;


        protected override void Awake()
        {
            this.rectTransform = GetComponent<RectTransform>();
        }


        public void SetState(PanelState value, bool sendCallback = true)
        {
            var previous = panelState;
            this.panelState = value;

            if (previous == value && sendCallback)
                OnStateChanged?.Invoke();
        }


        public void SetPosition(Vector2 value)
        {
            rectTransform.anchoredPosition = value;
        }

        public void SetScreenRelativePosition(Vector2 value)
        {
            rectTransform.SetScreenRelativePosition(value);
        }
    }
}