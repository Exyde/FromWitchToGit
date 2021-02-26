using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Interactable
{
	#region Public Fields
    [Header ("NPC Datas")]
	public string npcName;
    public Message startMessage;
    private Message currentMessage;
    public Response lastReponse;

    bool isTalking = false;

    [Header ("References")]
    public GameObject player;
    public GameObject dialogueUI;
    public MovementDatas moveDatas;

    [Space]
    [Header ("Npc Text Area")]
    public Text npcNameText;
    public Text npcMessageText;

    [Header("PlayerText Area")]
    public Text[] responsesText;
    //public Text QuitText;


    [Header ("Aura")]
    //Aura
    [Range (0, 100)]
    public float auraPct = 50f;
    #endregion

    void Start()
    {
        dialogueUI.SetActive(false);
        npcNameText.text = npcName;
        currentMessage = startMessage;
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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UpdateDialogue();
    }

    public void EndDialogue()
	{
        moveDatas.canSpell = moveDatas.canMove = true;
        isTalking = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogueUI.SetActive(false);
    }

    void UpdateDialogue()
	{
        npcMessageText.text = currentMessage.message;

        for (int i = 0; i < currentMessage.responses.Length; i++){
            responsesText[i].text = currentMessage.responses[i].response;
		}
    }

    public void LoadNextMessage()
	{
         
	}
}
