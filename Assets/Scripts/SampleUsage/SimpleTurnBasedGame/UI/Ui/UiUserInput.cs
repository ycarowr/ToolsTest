﻿using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Enable and Disable a CanvasGroup.
    /// </summary>
    public interface IUiUserInput
    {
        void Disable();
        void Enable();
    }

    /// <summary>
    ///     Class used to manage the UiUserInput upon a CanvasGroup.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class UiUserInput : MonoBehaviour, IUiUserInput
    {
        private CanvasGroup CanvasGroup { get; set; }

        void IUiUserInput.Disable()
        {
            CanvasGroup.interactable = false;
        }

        void IUiUserInput.Enable()
        {
            CanvasGroup.interactable = true;
        }

        private void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
        }
    }
}