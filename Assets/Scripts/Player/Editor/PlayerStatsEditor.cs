using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Stats))]
public class PlayerStatsEditor : Editor
{
    public Stats StatsTarget => target as Stats;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Reset Values"))
        {
            StatsTarget.ResetValues();
        }
        
    }
}
