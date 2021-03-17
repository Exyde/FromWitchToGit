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

    public ParticleSystem cinematicExplosionVFX;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spellShooter = FindObjectOfType<SpellShooter>();
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
        yield return new WaitForSeconds(clipA.length + 1f);

        VFX.SetActive(true);

        //Sequence B
        audioSource.clip = clipB;
        audioSource.Play();
        yield return new WaitForSeconds(clipB.length + 1f);

        //Cinematic end
        moveDatas.canMove = moveDatas.canSpell = true;
        spellShooter.UnlockDeconstruct();
        cinematicExplosionVFX.Play();

        moon.GetComponent<MeshRenderer>().material = updatedMoonMat;
        spellPanel.GetComponent<Image>().sprite = updatedSpellTexture;

        //spellShooter.transform.LookAt(moon.gameObject.transform);
        ///spellShooter.GetComponent<Health>().currentHealth = 3;
    }
}
