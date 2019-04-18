﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------
    
    #region Interface
    
    public interface IUiCardPile
    {
        void AddCard(IUiCard uiCard);
        void RemoveCard(IUiCard uiCard);
    }
    
    #endregion
    
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Pile of Cards, you can add or remove cards.
    /// </summary>
    public abstract class UiCardPile : MonoBehaviour, IUiCardPile
    {
        //--------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     List which contains all cards of this respective pile.
        /// </summary>
        public List<IUiCard> Cards { get; private set; }
        
        /// <summary>
        ///     Event raised when add or remove a card.
        /// </summary>
        public event Action<IUiCard[]> OnPileChanged = hand => { };
        

        //--------------------------------------------------------------------------------------------------------------
        
        #region Unitycallbacks
        
        protected virtual void Awake()
        {
            //initialize register
            Cards = new List<IUiCard>();

            Clear();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
            
        /// <summary>
        ///     Add a card to the pile.
        /// </summary>
        /// <param name="card"></param>
        public virtual void AddCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");
//
            Cards.Add(card);
            card.transform.SetParent(transform);
            card.Draw();
            NotifyPileChange();
        }


        /// <summary>
        ///     Remove a card from the pile.
        /// </summary>
        /// <param name="card"></param>
        public virtual void RemoveCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);

            NotifyPileChange();
        }
        
        //--------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Clear all the pile.
        /// </summary>
        [Button]
        protected virtual void Clear()
        {
            var childCards = GetComponentsInChildren<IUiCard>();
            foreach (var uiCardHand in childCards)
                Destroy(uiCardHand.gameObject);

            Cards.Clear();
        }

        /// <summary>
        ///     Notify all listeners of this pile that some change has been made.
        /// </summary>
        [Button]
        protected void NotifyPileChange()
        {
            OnPileChanged?.Invoke(Cards.ToArray());
        }
        
        //--------------------------------------------------------------------------------------------------------------
    }
}