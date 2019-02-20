using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tools;

[CustomEditor(typeof(ShakeAnimation))]
public class ShakeAnimationEditor : Editor
{
    private ShakeAnimation Target
    {
        get { return target as ShakeAnimation; }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            if (GUILayout.Button("Shake!"))
                Target.Shake();

            if (Target.isShaking && GUILayout.Button("Stop!"))
                Target.StopShaking();
        }
    }

}
