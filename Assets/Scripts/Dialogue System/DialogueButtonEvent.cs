using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogueButtonEvent : MonoBehaviour, IPointerClickHandler
{
	#region Public Fields
	public UnityEvent onClick;

	[HideInInspector]
    public Message nextMessage;
	[HideInInspector]
	public int auraAmount;

	#endregion
	private DialogueManager dialogueManager;

	private void Start()
	{
		dialogueManager = GetComponentInParent<DialogueManager>();
	}

	public void OnPointerClick(PointerEventData pointerEventData)
    {
        onClick.Invoke();
    }

    public void SetNextMessage()
	{
		//The function call on Click for the most of messages
		dialogueManager.SetNextMessage(nextMessage, auraAmount);
	}
}
