using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools.Dialog;
using UnityEngine;

namespace TestDialog
{
    /// <summary>
    ///     Testing the Dialog System.
    /// </summary>
    public class TestDialog : MonoBehaviour
    {
        public TextSequence TestSequence;
        public DialogSystem Dialog;
        public TextButton ButtonRed;
        public TextButton ButtonGreen;
        public TextButton ButtonBlue;
        public TMP_Text Ctrl;

        private void Awake()
        {
            ButtonGreen.OnPress.AddListener(() => SetCtrlTo("Bulbasaur, my best."));
            ButtonRed.OnPress.AddListener(() => SetCtrlTo("Manipulated by the mass, take Charmander."));
            ButtonBlue.OnPress.AddListener(() => SetCtrlTo("Hipster... Squirtle for you."));
        }


        [Button]
        public void Show()
        {
            Dialog.Show();
        }
        
        [Button]
        public void Hide()
        {
            Dialog.Hide();
        }
        
        [Button]
        public void Write()
        {
            Dialog.Write(TestSequence);
            Reset();
        }

        public void SetCtrlTo(string txt)
        {
            Ctrl.text = txt;
        }

        public void Reset()
        {
            SetCtrlTo("");
        }
    }
}