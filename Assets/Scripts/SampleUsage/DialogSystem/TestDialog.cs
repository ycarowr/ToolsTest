using System.Collections;
using System.Collections.Generic;
using Tools.Dialog;
using UnityEngine;

namespace TestDialog
{
    public class TestDialog : MonoBehaviour
    {
        public TextSequence TestSequence;
        public DialogSystem Dialog;
        public TextButton ButtonLogYes;
        public TextButton ButtonLogNo;

        private void Awake()
        {
            ButtonLogNo.OnPress.AddListener(()=>Debug.Log("no"));
            ButtonLogNo.OnPress.AddListener(Dialog.Hide);
            ButtonLogNo.Text = "LogNo";
            ButtonLogYes.OnPress.AddListener(()=>Debug.Log("yes"));
            ButtonLogYes.OnPress.AddListener(Dialog.Hide);
            ButtonLogYes.Text = "LogYes";
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
        }
    }
}