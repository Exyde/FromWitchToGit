using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Interactable
{
	#region Public Fields
    [Header ("For Game Design")]
	public string npcName;
    public Message startMessage;

    private Message currentMessage;
    private bool isTalking = false;

    [Header("References")]
    public GameObject DialoguesCanvas;
    public GameObject player;
    public GameObject dialogueUI;
    public MovementDatas moveDatas;

    [Space]
    [Header ("Npc Text Area")]
    public Text npcNameText;
    public Text npcMessageText;

    [Header("Player Text Area")]
    public Text[] responsesText;

    [Header ("Aura")]
    [Range (0, 100)]
    public int auraAmount = 50;
    public MeshRenderer meshRenderer;
    public Color auraColor;
    #endregion

    void Start()
    {
        DialoguesCanvas.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueUI.SetActive(false);

        npcNameText.text = npcName;
        currentMessage = startMessage;

        ComputeAuraColor();
    }

	#region Interaction System Overrides
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
	#endregion

	#region Dialogue Methodes
	//Disable movement, spells, set talking, enable UI, reset dialogue, unlock cursor.
	//Call Update Dialogue()
	void BeginDialogue()
	{
        moveDatas.canSpell = moveDatas.canMove = false;
        isTalking = true;
        dialogueUI.SetActive(true);
        currentMessage = startMessage;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UpdateDialogue();
    }

    //Enable spells and movement, set talking to false, disable UI, lock cursor.
    public void EndDialogue()
	{
        moveDatas.canSpell = moveDatas.canMove = true;
        isTalking = false;
        dialogueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UpdateDialogue()
	{
        //Grab the text from the Message SO.
        npcMessageText.text = currentMessage.message;
        
        //Explore all the Text fields (-1 for Quit), empty the message and disable the UI.
        for (int i = 0; i < responsesText.Length - 1; i++)
		{
            responsesText[i].text = "";
            responsesText[i].gameObject.SetActive(false);
		}

        
        if (!currentMessage.endDialogue)
		{
            //Enable UI for the concerned message, grab the response text, and apply the data to the DialogueButtonEvent message and aura value.
            //Todo : Refactoring : GetComponent in the start Method.
            for (int i = 0; i < currentMessage.responses.Length; i++)
            {
                responsesText[i].gameObject.SetActive(true);
                responsesText[i].text = currentMessage.responses[i].response;
                responsesText[i].GetComponent<DialogueButtonEvent>().nextMessage = currentMessage.responses[i].nextMessage;
                responsesText[i].GetComponent<DialogueButtonEvent>().auraAmount = currentMessage.responses[i].auraValue;
            }
        }
    }
	#endregion

    //Called from the DialogueButtonEvent, On Click.
    public void SetNextMessage(Message newMessage, int _auraAmount)
	{
        currentMessage = newMessage;
        auraAmount = _auraAmount;

        ComputeAuraColor();
        //UpdateAura();
        UpdateDialogue();
	}

    void UpdateAura()
	{
        Material[] materials = meshRenderer.materials;
        materials[1].color = new Color(0 , 0 , 0, 1);
        meshRenderer.materials = materials;
    }

    void ComputeAuraColor()
	{
        int c = 255 * auraAmount / 100;
        auraColor = new Color(c, c, c, 1);
        //Main
        //meshRenderer.material.SetColor("Color_7d0a97e1d3a94d278b28b53ff0160b8b", auraColor);
        meshRenderer.material.SetColor("Color_3cd2912bd2dd485389e3a1a21e51c4b3", auraColor);
    }
}
