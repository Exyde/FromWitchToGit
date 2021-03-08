using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor (typeof (EntitySpawner))]
public class EntitySpawnerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		EntitySpawner ES = (EntitySpawner)target;

		DrawDefaultInspector();

		if (GUILayout.Button("Generate Assets"))
		{
			ES.GenerateAssets();
		}

		if (GUILayout.Button("Clear Transform"))
		{
			ES.ClearTransform();
		}
	}
}
#endif