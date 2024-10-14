using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
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
#endif