using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerUserInput : UiPlayerUserBase
    {
        private CanvasGroup CanvasGroup { get; }
        
        public UiPlayerUserInput(UiPlayerUserContainer handler) : base(handler)
        {
            CanvasGroup = handler.GetComponent<CanvasGroup>();
        }
        
        public void DisableInput()
        {
            CanvasGroup.interactable = false;
        }

        public void EnableInput()
        {
            CanvasGroup.interactable = true;
        }
    }
}