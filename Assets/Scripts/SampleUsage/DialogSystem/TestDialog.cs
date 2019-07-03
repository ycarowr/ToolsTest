using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace TestDialog
{
    public class TestDialog : MonoBehaviour
    {
        public TextSequence TestSequence;
        public DialogSystem Dialog;

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
        }
    }
}