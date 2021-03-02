using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorcelable : MonoBehaviour
{
    // 6max : dynamic array, enable/disable the usesless one from hp

    [Header ("References")]
    public GameObject deconstructPanel;
    public GameObject instructPanel;
    public GameObject moonContainerPrefab;
    public GameObject chainContainerPrefab;

    [Header("Deconstruct Data")]
    [Range (0, 6)]
    public int MaxDeconstructHP;
    public int deconstructHP;


    [Header("Instruct Data")]
    [Range(0, 6)]
    public int MaxInstructHP;
    public int instructHP;

    void Start()
    {
        CreateContainerUI(moonContainerPrefab, instructPanel.transform, MaxDeconstructHP);
        CreateContainerUI(chainContainerPrefab, deconstructPanel.transform, MaxInstructHP);
    }

    void Update()
    {
        
    }

    void CreateContainerUI(GameObject container, Transform parent, int maxHp)
	{
        float w = parent.GetComponent<RectTransform>().sizeDelta.x;
        int n = maxHp;
        float l = container.GetComponent<RectTransform>().sizeDelta.x;

        float offset = (w - (l * n)) / n;
        print(offset);

        for (int i = 0; i < maxHp; i++)
		{
            GameObject go = Instantiate(container, new Vector3(i, 0, 0), Quaternion.identity);
            go.transform.SetParent(parent, false);
		}
	}
}
