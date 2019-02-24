using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UiPlayerUserContainer : UiPlayerContainer
    {
        public UiPlayerUserButtons UiPlayerUserButtons { get; private set; }
        public UiPlayerUserInput UiPlayerUserInput { get; private set; }

        protected void Awake()
        {
            gameObject.AddComponent<UiStartUserTurn>();
            gameObject.AddComponent<UiFinishUserTurn>();

            UiPlayerUserButtons = new UiPlayerUserButtons(this);
            UiPlayerUserInput = new UiPlayerUserInput(this);

            UiPlayerUserInput.DisableInput();
        }
    }
}