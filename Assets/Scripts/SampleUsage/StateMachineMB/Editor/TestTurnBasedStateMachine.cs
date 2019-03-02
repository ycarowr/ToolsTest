using System.Collections;
using System.Collections.Generic;
using ExampleStateMachine;
using SimpleTurnBasedGame;
using UnityEngine;
using UnityEditor;

namespace SimpleTurnBasedGame
{ 
    [CustomEditor(typeof(TurnBasedStateMachine))]
    public class TestTurnBasedStateMachine : Editor
    {
        private TurnBasedStateMachine Target
        {
            get { return target as TurnBasedStateMachine; }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!Application.isPlaying)
                return;
            if (GUILayout.Button("Push: " + typeof(PlayerStateTurn)))
                Target.PushState<PlayerStateTurn>();

            if (GUILayout.Button("Push: " + typeof(AiStateTurn)))
                Target.PushState<AiStateTurn>();

            var current = Target.PeekState();

            if (current == null)
                return;

            if (GUILayout.Button("Pop: " + current.GetType()))
                Target.PopState();
        }
    }
}