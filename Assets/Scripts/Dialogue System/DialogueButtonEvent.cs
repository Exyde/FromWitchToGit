using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogueButtonEvent : MonoBehaviour, IPointerClickHandler
{

	private DialogueManager dialogueManager;
    public UnityEvent onClick;

    public Message nextMessage;

	private void Start()
	{
		dialogueManager = GetComponentInParent<DialogueManager>();
		print(dialogueManager.name);
	}

	public void OnPointerClick(PointerEventData pointerEventData)
    {
        onClick.Invoke();
    }

    public void SetNextMessage()
	{
		dialogueManager.SetNextMessage(nextMessage);
	}
}
