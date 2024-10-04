using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Doll))]
public class DollEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Doll manager = (Doll)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Take Off All"))
        {
            manager.TakeOffDoll();
        }

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
