using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    /// This interface request the client to return a CanvasGroup.
    /// </summary>
    public interface IUiCanvasGroupHandler
    {
        CanvasGroup CanvasGroup { get; }
    }

    /// <summary>
    /// Enable and Disable a CanvasGroup.
    /// </summary>
    public interface IUiCanvasGroupInput
    {
        void Disable();
        void Enable();
    }

    /// <summary>
    /// Class used to manage the Input upon a CanvasGroup.
    /// </summary>
    public class UiCanvasGroupInput : IUiCanvasGroupInput, IUiCanvasGroupHandler
    {
        public CanvasGroup CanvasGroup { get; }

        public UiCanvasGroupInput(IUiCanvasGroupHandler handler)
        {
            CanvasGroup = handler.CanvasGroup;
        }
        
        public void Disable()
        {
            CanvasGroup.interactable = false;
        }

        public void Enable()
        {
            CanvasGroup.interactable = true;
        }
    }
}