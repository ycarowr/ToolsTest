using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UiButton : MonoBehaviour
    {
        protected Button Button { get; set; }

        protected virtual void Awake()
        {
            if (Button == null)
                Button = GetComponent<Button>();
        }

        public virtual void AddListener(UnityAction action)
        {
            Button.onClick.AddListener(action);
        }

        public virtual void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }
    }
}