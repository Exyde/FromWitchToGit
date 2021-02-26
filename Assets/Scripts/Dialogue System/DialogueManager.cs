using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Interactable
{
    public string npcName;

    bool isTalking = false;

    public GameObject player;
    public GameObject dialogueUI;
    public MovementDatas moveDatas;

    public Text npcNameText;
    public Text npcDialogueBox;

    public Message startMessage;

    //Aura
    [Range (0, 100)]
    public float auraPct = 50f;

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    public override string GetDescription()
    {
        if (isTalking) return "";
        return "Parler a " + npcName;
    }

	public override void Interact()
	{
        if (!isTalking) BeginDialogue();
        else EndDialogue();
	}

    void BeginDialogue()
	{
        moveDatas.canSpell = moveDatas.canMove = false;
        isTalking = true;
        dialogueUI.SetActive(true);
	}

    void EndDialogue()
	{
        moveDatas.canSpell = moveDatas.canMove = true;
        isTalking = false;
        dialogueUI.SetActive(false);
    }
}
