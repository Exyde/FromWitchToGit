using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (ForestSpawner))]
public class ForestEditor : Editor
{
	public override void OnInspectorGUI()
	{
		ForestSpawner FS = (ForestSpawner)target;

		DrawDefaultInspector();

		if (GUILayout.Button("Generate Forest"))
		{
			FS.GenerateForest();
		}

		if (GUILayout.Button("Clear Forest"))
		{
			FS.ClearForest();
		}
	}
}
