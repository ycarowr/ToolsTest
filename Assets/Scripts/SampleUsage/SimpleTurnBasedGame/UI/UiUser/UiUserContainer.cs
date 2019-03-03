using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     User HUD
    /// </summary>
    public class UiUserContainer : UiPlayerContainer,
        IUiCanvasGroupHandler,
        IUiUserContainerHandler
    {
        public UiUserHudButtons UiUserHudButtons { get; private set; }
        public UiCanvasGroupInput UiUserHudInput { get; private set; }
        CanvasGroup IUiCanvasGroupHandler.CanvasGroup => GetComponent<CanvasGroup>();
        UiUserContainer IUiUserContainerHandler.Container => this;

        protected void Awake()
        {
            //Ui elements for pre start game
            gameObject.AddComponent<UiPreStartGameUser>();

            //Ui elements for start user turn
            gameObject.AddComponent<UiStartUserTurn>();

            //Ui elements for finish user turn
            gameObject.AddComponent<UiFinishUserTurn>();

            //HUD buttons
            UiUserHudButtons = new UiUserHudButtons(this);

            //HUD input
            UiUserHudInput = new UiCanvasGroupInput(this);
        }
    }
}