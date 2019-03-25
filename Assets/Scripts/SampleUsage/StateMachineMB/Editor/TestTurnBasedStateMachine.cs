using ExampleStateMachine;
using UnityEditor;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    [CustomEditor(typeof(ExampleStateMachine.TurnBasedStateMachine))]
    public class TestTurnBasedStateMachine : Editor
    {
        private ExampleStateMachine.TurnBasedStateMachine Target => target as ExampleStateMachine.TurnBasedStateMachine;

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