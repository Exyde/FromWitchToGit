using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CovenInteraction : Interactable
{
    public bool interacted = false;
    public MovementDatas moveDatas;

    [Header ("Audio References")]
    AudioSource audioSource;
    public AudioClip clipA, clipB;

    SpellShooter spellShooter;

    public GameObject moon;
    public GameObject spellPanel;
    public Material updatedMoonMat;
    public Sprite updatedSpellTexture;
    public GameObject VFX;
    public GameObject TutoPanel;

    public GameObject SousTitreA;
    public GameObject SousTitreB;


    public ParticleSystem cinematicExplosionVFX;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spellShooter = FindObjectOfType<SpellShooter>();
        TutoPanel.SetActive(false);

        SousTitreA.SetActive(false);
        SousTitreB.SetActive(false);

    }
    public override string GetDescription()
    {
        if (!interacted) return "Examiner [E]";
        return "...";
    }

    public override void Interact()
    {
        if (!interacted) StartCoroutine(CovenCinematic());
    }

    IEnumerator CovenCinematic()
    {
        //Todo : ADD SFX, VFX, Camera movement, Animations, Meshes.

        //Disable movement, position camera...
        moveDatas.canMove = moveDatas.canSpell = false;
        interacted = true;

        //Sequence A
        audioSource.clip = clipA;
        audioSource.Play();
        SousTitreA.SetActive(true);
        yield return new WaitForSeconds(clipA.length + .5f);
        SousTitreA.SetActive(false);

        VFX.SetActive(true);
        cinematicExplosionVFX.Play();

        //Sequence B
        audioSource.clip = clipB;
        audioSource.Play();
        SousTitreB.SetActive(true);
        yield return new WaitForSeconds(clipB.length + .5f);
        SousTitreB.SetActive(false);


        //Cinematic end
        moveDatas.canMove = moveDatas.canSpell = true;
        spellShooter.UnlockDeconstruct();

        moon.GetComponent<MeshRenderer>().material = updatedMoonMat;
        spellPanel.GetComponent<Image>().sprite = updatedSpellTexture;
        TutoPanel.SetActive(true);


        //spellShooter.transform.LookAt(moon.gameObject.transform);
        ///spellShooter.GetComponent<Health>().currentHealth = 3;
    }
}
