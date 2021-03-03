using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorcelable : MonoBehaviour
{
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
        deconstructHP = MaxDeconstructHP;
        instructHP = MaxInstructHP;

        CreateContainerUI(moonContainerPrefab, instructPanel.transform, MaxInstructHP);
        CreateContainerUI(chainContainerPrefab, deconstructPanel.transform, MaxDeconstructHP);
    }

    void CreateContainerUI(GameObject container, Transform parent, int maxHp)
	{
        //Not sure why it's working, but it's working

        float w = parent.GetComponent<RectTransform>().sizeDelta.x;
        int n = maxHp;
        float l = container.GetComponent<RectTransform>().sizeDelta.x;

        float offset = (w - (l * n)) / n;

        for (int i = 0; i < maxHp; i++)
		{
            GameObject go = Instantiate(container, new Vector3(i, 0, 0), Quaternion.identity);
            go.transform.SetParent(parent, false);
		}
	}

    public void TakeDamage(Spell spell)
	{
        //Todo :Check for null
        if (spell.Deconstruct)
        {
            if (deconstructHP > 0)
			{
                deconstructHP--;
                int lasthp = deconstructPanel.transform.childCount - 1;
                print("Deconstruct hp last index : " + lasthp);

                Destroy(deconstructPanel.transform.GetChild(lasthp).gameObject);
			}
        }
        else if (spell.Instruct)
        {
            if (deconstructHP <= 0 && instructHP > 0)
			{
                instructHP--;
                int lasthp = instructPanel.transform.childCount - 1;
                print("Instruct hp last index : " + lasthp);

                Destroy(instructPanel.transform.GetChild(lasthp).gameObject);
			}
        }
        else return;
	}
}
