using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class EntitySpawner : MonoBehaviour
{
    public GameObject assetPrefab;
    public float gridSize = 10f;
    public float offset = 1f;

	[Header ("Random Configuration")]
	public bool randomScale = false;
	public Vector2 scaleBounds;
	public bool randomRotation = false;

    void Start()
    {
        //GenerateForest();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			GenerateAssets();
		}
	}
	public void GenerateAssets()
	{
		ClearTransform();

		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				float randOffset = Random.Range(-2f, 2f);

				Vector3 pos = new Vector3(i * offset + randOffset, 0 ,j * offset + randOffset);
				Vector3 rot = new Vector3(270, 0, 0);
				Vector3 finalScale = new Vector3(1, 1, 1);

				if (randomRotation)
				{
					rot = new Vector3(270, Random.Range(0, 360f), Random.Range(-10f, 10f));
				}

				if (randomScale)
				{
					float scale = Random.Range(scaleBounds.x, scaleBounds.y);
					finalScale = new Vector3(scale, scale, scale);
				}

				var tree = Instantiate(assetPrefab, pos, Quaternion.Euler(rot)) as GameObject;
				tree.transform.localScale = finalScale;
				tree.transform.SetParent(this.transform);
			}
		}
	}

	public void ClearTransform()
	{
		int childs = transform.childCount;

		for (int i = 0; i < childs; i++)
		{
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
	}
}
