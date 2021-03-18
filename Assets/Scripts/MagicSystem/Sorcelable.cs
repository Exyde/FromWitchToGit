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
    public Sprite EyeOpenedTexture;

    public GameObject ChainDestructionPrefab;
    public GameObject EyeOpeningPrefab;

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
    public bool boss = false;

    [Header("Audio Feedback")]
    public AudioClip[] deconstructFeedbacksAudio;
    public AudioClip[] instructFeedbacksAudio;


    AudioSource audioSource;


    void Start()
    {
        //Setup both hp values
        deconstructHP = MaxDeconstructHP;
        instructHP = 0;

        //Create the UI Bar Elements
        CreateContainerUI(moonContainerPrefab, instructPanel.transform, MaxInstructHP);
        CreateContainerUI(chainContainerPrefab, deconstructPanel.transform, MaxDeconstructHP);

        audioSource = GetComponent<AudioSource>();
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

                Instantiate(ChainDestructionPrefab, transform.position, Quaternion.identity);
                Destroy(deconstructPanel.transform.GetChild(childIndex).gameObject);

                audioSource.clip = deconstructFeedbacksAudio[Random.Range(0, deconstructFeedbacksAudio.Length)];
                audioSource.Play();

                if (deconstructHP == 0 && instructHP == MaxInstructHP)
				{
                    StartCoroutine(FreeEntity());
                }
            }
        }
        // Instruct Spell - Second Health Bar
        else if (spell.Instruct)
        {
            if (deconstructHP <= 0 && instructHP < MaxInstructHP)
			{
                instructHP++;
                int childIndex = instructHP - 1;

                //Add eye opening
                instructPanel.transform.GetChild(childIndex).GetComponent<Image>().sprite = EyeOpenedTexture;
                instructPanel.transform.GetChild(childIndex).GetComponent<Image>().color = instructColor;
                Instantiate(EyeOpeningPrefab, transform.position, Quaternion.identity);

                audioSource.clip = instructFeedbacksAudio[Random.Range(0, instructFeedbacksAudio.Length)];
                audioSource.Play();


                if (instructHP == MaxInstructHP)
				{
                    if (boss) FindObjectOfType<GameManager>().HandleGameEnd();
                    else StartCoroutine(FreeEntity());
				}
			}
        }
        else return;
	}

    IEnumerator FreeEntity()
	{
        //Function for freeing the Entity. Summon the healed entity, the malveillent leaving fx, and some impact I guess.
        Rigidbody rb = null;
        EnemyAI ai = null;

        //Aplly gravity
        TryGetComponent<Rigidbody>(out rb);
        if (rb != null)
		{
            rb.useGravity = true;
		}

        //Disable movement
        TryGetComponent<EnemyAI>(out ai);
        if (ai != null)
		{
            ai.enabled = false;
		}

        iTween.ScaleTo(this.gameObject, iTween.Hash("x", .5, "z", .5, "y", .5));

        yield return new WaitForSeconds(1f);

        Instantiate(FreeEntityPrefab, transform.position, FreeEntityPrefab.transform.rotation);
        Instantiate(FreeFXPrefab, transform.position, Quaternion.identity);
        Instantiate(MalveillantFXPrefab, transform.position, MalveillantFXPrefab.transform.rotation);

        Destroy(this.gameObject);
	}
}
