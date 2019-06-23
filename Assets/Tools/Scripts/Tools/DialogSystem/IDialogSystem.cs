﻿using System;
using UnityEngine;

namespace Tools
{
    /// <summary>
    ///     A dialog system interface.
    /// </summary>
    public interface IDialogSystem
    {
        /// <summary>
        ///     The monobehavior attached to the system.
        /// </summary>
        MonoBehaviour Monobehavior { get; }

        /// <summary>
        ///     OnShow Event.
        /// </summary>
        Action OnShow { get; }

        /// <summary>
        ///     OnHide Event.
        /// </summary>
        Action OnHide { get; }

        /// <summary>
        ///     OnHide Finish Sequence Event.
        /// </summary>
        Action OnFinishSequence { get; set; }

        /// <summary>
        ///     Tells whether the window is opened or not.
        /// </summary>
        bool IsOpened { get; }

        /// <summary>
        ///     Speed the text is written to the user.
        /// </summary>
        int Speed { get; }

        /// <summary>
        ///     If active, show the dialog in the screen in the same position it was before.
        /// </summary>
        void Show();

        /// <summary>
        ///     Hide the dialog screen.
        /// </summary>
        void Hide();

        /// <summary>
        ///     Activate the gameobject.
        /// </summary>
        void Activate();

        /// <summary>
        ///     Deactivate the gameObject.
        /// </summary>
        void Deactivate();

        /// <summary>
        ///     If active, write a text to the user.
        /// </summary>
        /// <param name="text"></param>
        void Write(string text, string author);

        /// <summary>
        ///     Clear the text.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Calls next text sequence.
        /// </summary>
        void WriteNext();
    }
}