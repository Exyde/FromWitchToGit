using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovenInteraction : Interactable
{
    public bool interacted = false;
    public MovementDatas moveDatas;

    [Header ("Audio References")]
    AudioSource audioSource;
    public AudioClip clipA, clipB;

    SpellShooter spellShooter;

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

        //Sequence B
        audioSource.clip = clipB;
        audioSource.Play();
        yield return new WaitForSeconds(clipB.length + 1f);


        //Set active on the correct Stell

        //Cinematic end
        moveDatas.canMove = moveDatas.canSpell = true;
        spellShooter.UnlockDeconstruct();
    }
}
