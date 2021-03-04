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
    public float offset = .8f;

    [Header("Deconstruct Data")]
    [Range (0, 6)]
    public int MaxDeconstructHP;
    public int deconstructHP;


    [Header("Instruct Data")]
    [Range(0, 6)]
    public int MaxInstructHP;
    public int instructHP;
    public Color instructColor = new Color(1, 235, 255, 255);


    [Header("Liberation References")]
    public GameObject FreeEntityPrefab;
    public GameObject FreeFXPrefab;
    public GameObject MalveillantFXPrefab;

    void Start()
    {
        //Setup both hp values
        deconstructHP = MaxDeconstructHP;
        instructHP = 0;

        //Create the UI Bar Elements
        CreateContainerUI(moonContainerPrefab, instructPanel.transform, MaxInstructHP);
        CreateContainerUI(chainContainerPrefab, deconstructPanel.transform, MaxDeconstructHP);
    }

    void CreateContainerUI(GameObject container, Transform parent, int maxHp)
	{
        for (int i = 0; i < maxHp; i++)
		{
            GameObject go = Instantiate(container, new Vector3(i / offset, 0, 0), Quaternion.identity);
            go.transform.SetParent(parent, false);
		}
	}

    public void TakeDamage(Spell spell)
	{
        //Debug
        if (spell == null)
		{
            Debug.Log("Null reference exception !");
		}
        
        //Deconstruct Spell - First Health Bar
        if (spell.Deconstruct)
        {
            if (deconstructHP > 0)
			{
                deconstructHP--;
                int childIndex = deconstructPanel.transform.childCount - 1;

                Destroy(deconstructPanel.transform.GetChild(childIndex).gameObject);
			}
        }
        // Instruct Spell - Second Health Bar
        else if (spell.Instruct)
        {
            if (deconstructHP <= 0 && instructHP < MaxInstructHP)
			{
                instructHP++;
                int childIndex = instructHP - 1;

                instructPanel.transform.GetChild(childIndex).GetComponent<Image>().color = instructColor;

                if (instructHP == MaxInstructHP)
				{
                    StartCoroutine(FreeEntity());
				}
			}
        }
        else return;
	}

    IEnumerator FreeEntity()
	{
        //Function for freeing the Entity. Summon the healed entity, the malveillent leaving fx, and some impact I guess.

        iTween.ScaleTo(this.gameObject, iTween.Hash("x", .5, "z", .5, "y", .5));

        yield return new WaitForSeconds(1f);

        Instantiate(FreeEntityPrefab, transform.position, FreeEntityPrefab.transform.rotation);
        Instantiate(FreeFXPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
	}
}