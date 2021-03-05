using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class EntitySpawner : MonoBehaviour
{
	[Header ("Pour toi, JEAN <3")]
    public GameObject assetPrefab;
	public float largeur = 1f;
	public float longueur = 1f;
    public float offset = 1f;

	[Header ("Random Configuration")]
	public bool randomScale = false;
	public Vector2 scaleBounds;
	public bool randomRotation = false;

	[Header("Transform References")]
	public Transform Handles;
	public Transform TopLeft;
	public Transform TopRight;
	public Transform BottomLeft;
	public Transform BottomRight;

	public Transform EntitiesHolder;
	public float gridSize = 10f;

	public void GenerateAssets()
	{
		ClearTransform();

		for (int i = 0; i < largeur; i++)
		{
			for (int j = 0; j < longueur; j++)
			{
				float randOffset = Random.Range(-2f, 2f);
				randOffset = 0;

				Vector3 pos = new Vector3(i * offset + randOffset, 0 ,j * offset + randOffset);
				Vector3 rot = new Vector3(270, 0, 0);
				Vector3 finalScale = assetPrefab.transform.localScale;

				if (randomRotation)
				{
					rot = new Vector3(270, Random.Range(0, 360f), Random.Range(-10f, 10f));
				}

				if (randomScale)
				{
					float scale = Random.Range(scaleBounds.x, scaleBounds.y);

					finalScale *= scale;
				}

				var tree = Instantiate(assetPrefab, pos, Quaternion.Euler(rot)) as GameObject;
				tree.transform.localScale = finalScale;
				tree.transform.SetParent(EntitiesHolder);
			}
		}
	}

	public void ClearTransform()
	{
		int childs = EntitiesHolder.childCount;

		for (int i = 0; i < childs; i++)
		{
			DestroyImmediate(EntitiesHolder.GetChild(0).gameObject);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		/*
		Gizmos.DrawWireSphere(TopLeft.position, .1f);
		Gizmos.DrawWireSphere(TopRight.position, .1f);
		Gizmos.DrawWireSphere(BottomLeft.position, .1f);
		Gizmos.DrawWireSphere(BottomRight.position, .1f);
		*/

		Gizmos.color = Color.green;


		TopRight.position = TopLeft.position + (new Vector3(largeur - 1, 0, 0) * offset);
		BottomRight.position = TopRight.position + (new Vector3(0, 0, longueur- 1) * offset);
		BottomLeft.position = TopLeft.position + (new Vector3(0, 0, longueur - 1) * offset);


		Gizmos.DrawLine(TopLeft.position, TopRight.position);
		Gizmos.DrawLine(TopLeft.position, BottomLeft.position);
		Gizmos.DrawLine(TopRight.position, BottomRight.position);
		Gizmos.DrawLine(BottomLeft.position, BottomRight.position);

		Gizmos.color = Color.red;

		for (int i = 0; i < largeur; i++)
		{
			for (int j = 0; j < longueur; j++)
			{
				Gizmos.DrawWireSphere(new Vector3(i * offset, 0, j * offset), (largeur + longueur) / 10f);
			}
		}

	}
}
