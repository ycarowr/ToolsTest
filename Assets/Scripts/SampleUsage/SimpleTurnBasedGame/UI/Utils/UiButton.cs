using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public interface IButtonHandler
    {

    }

    public abstract class UiButton : MonoBehaviour
    {
        protected Button Button { get; set; }

        protected virtual void Awake()
        {
            if (Button == null)
                Button = GetComponent<Button>();
        }

        public virtual void AddListener(UnityAction action)
        {
            if(action != null)
                Button.onClick.AddListener(action);
        }

        public virtual void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }

        public abstract void SetHandler(IButtonHandler handler);
    }
}