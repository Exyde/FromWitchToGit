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
        GenerateForest();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			GenerateForest();
		}
	}
	void GenerateForest()
	{
		ClearTransform();

		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				float randOffset = Random.Range(-2f, 2f);

				Vector3 pos = new Vector3(i * offset + randOffset, 3 ,j * offset + randOffset);
				Vector3 rot = new Vector3(270, 0, 0);
				float scale = Random.Range(.2f, 3f);
				Vector3 randomScale = new Vector3(scale, scale, scale);


				var tree = Instantiate(TreePrefab, pos, Quaternion.Euler(rot)) as GameObject;
				tree.transform.localScale = randomScale;
				tree.transform.SetParent(this.transform);
			}
		}
	}

	void ClearTransform()
	{
		int i = transform.childCount;

		for (int x = 0; x < i; x++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
}
