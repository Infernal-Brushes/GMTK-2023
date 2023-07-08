using Enemy;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Aiming))]
public class Aiming_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        Aiming targ = (Aiming) target;

        base.OnInspectorGUI();
        if (GUILayout.Button("Play aiming"))
        {
            targ.Setup();
        }
    }
}