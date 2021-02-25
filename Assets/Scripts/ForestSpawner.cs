using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ForestSpawner : MonoBehaviour
{
    public GameObject TreePrefab;
    public float gridSize = 10f;
    public float offset = 1f;

    void Start()
    {
        //GenerateForest();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			GenerateForest();
		}
	}
	public void GenerateForest()
	{
		ClearForest();

		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				float randOffset = Random.Range(-2f, 2f);

				Vector3 pos = new Vector3(i * offset + randOffset, 0 ,j * offset + randOffset);
				Vector3 rot = new Vector3(270, Random.Range(0, 360f), Random.Range(-10f, 10f));
				float scale = Random.Range(.2f, 3f);
				Vector3 randomScale = new Vector3(scale, scale, scale);

				var tree = Instantiate(TreePrefab, pos, Quaternion.Euler(rot)) as GameObject;
				tree.transform.localScale = randomScale;
				tree.transform.SetParent(this.transform);
			}
		}
	}

	public void ClearForest()
	{
		int childs = transform.childCount;

		for (int i = 0; i < childs; i++)
		{
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
	}
}
