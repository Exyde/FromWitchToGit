using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueButtonEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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

        Color c = GetComponent<Text>().color;
        c.a = .7f;
        GetComponent<Text>().color = c;
    }

	public void OnPointerClick(PointerEventData pointerEventData)
    {
        onClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color c = GetComponent<Text>().color;
        c.a = 1f;

        GetComponent<Text>().color = c;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color c = GetComponent<Text>().color;
        c.a = .7f;

        GetComponent<Text>().color = c;
    }

    public void SetNextMessage()
	{
		//The function call on Click for the most of messages
		dialogueManager.SetNextMessage(nextMessage, auraAmount);
	}
}
