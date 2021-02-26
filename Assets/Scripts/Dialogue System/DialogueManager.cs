using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Current Dialogue Loaded. Can Changed.
    //Can have multiple dialogue et switch it based on npcc current state
    public NPC currentNPC;

    bool isTalking = false;
    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;

    public Text[] playerReponses;

    void Start()
    {
        dialogueUI.SetActive(false);
    }


    //Todo : Update with Raycast
	private void OnMouseOver()
	{
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= 2.5f)
		{
            if (Input.GetKeyDown(KeyCode.E) && !isTalking)
			{
                BeginDialogue();
			} else if (Input.GetKeyDown(KeyCode.E) && isTalking)
			{
                EndDialogue();
			}

        }
	}

    void BeginDialogue()
	{
        isTalking = true;
        dialogueUI.SetActive(true);
        curResponseTracker = 0;
	}

    void EndDialogue()
	{
        isTalking = false;
        dialogueUI.SetActive(false);
        //curResponseTracker = 0;
    }
}
